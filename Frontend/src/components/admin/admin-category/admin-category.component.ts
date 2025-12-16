import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import Swal from 'sweetalert2';

import { CategoryService } from '../../../services/category-service';
import { CategoryDto } from '../../../models/category/category-dto';
import { CategoryCreate } from '../../../models/category/category-create-dto';


@Component({
  selector: 'app-admin-category',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './admin-category.component.html',
  styleUrl: './admin-category.component.scss',
})
export class AdminCategoryComponent implements OnInit {
  private readonly categoriesService = inject(CategoryService);
  private readonly fb = inject(FormBuilder);

  loading = false;
  error: string | null = null;

  search = '';

  isModalOpen = false;
  mode: 'create' | 'edit' = 'create';
  editing: CategoryDto | null = null;

  form = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(2)]],
    description: [''],
  });

  ngOnInit(): void {
    this.loadCategories();
  }

  categories: CategoryDto[] = [];

  get filteredCategories(): CategoryDto[] {
    const q = this.search.trim().toLowerCase();
    if (!q) return this.categories;

    return this.categories.filter((c) => {
      const name = (c.name ?? '').toLowerCase();
      const desc = (c.description ?? '').toLowerCase();
      return name.includes(q) || desc.includes(q);
    });
  }

  loadCategories(): void {
    this.loading = true;
    this.error = null;

    this.categoriesService.getAll().subscribe({
      next: (cats) => {
        this.categories = (cats ?? []).slice().sort((a, b) => a.name.localeCompare(b.name));
        this.loading = false;
      },
      error: () => {
        this.error = 'Грешка при зареждане на категориите.';
        this.loading = false;
      },
    });
  }

  openCreate(): void {
    this.mode = 'create';
    this.editing = null;

    this.form.reset({
      name: '',
      description: '',
    });

    this.isModalOpen = true;
  }

  openEdit(cat: CategoryDto): void {
    this.mode = 'edit';
    this.editing = cat;

    this.form.reset({
      name: cat.name ?? '',
      description: cat.description ?? '',
    });

    this.isModalOpen = true;
  }

  closeModal(): void {
    this.isModalOpen = false;
  }

  save(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const payload: CategoryCreate = {
      name: this.form.value.name!.trim(),
      description: (this.form.value.description ?? '').trim(),
    };

    if (this.mode === 'create') {
      this.categoriesService.create(payload).subscribe({
        next: async () => {
          this.closeModal();
          await Swal.fire({
            icon: 'success',
            title: 'Създадена категория',
            timer: 1200,
            showConfirmButton: false,
          });
          this.loadCategories();
        },
        error: async () => {
          await Swal.fire({
            icon: 'error',
            title: 'Грешка',
            text: 'Неуспешно създаване на категория.',
          });
        },
      });

      return;
    }

    if (!this.editing) return;

    this.categoriesService.edit(this.editing.id, payload).subscribe({
      next: async () => {
        this.closeModal();
        await Swal.fire({
          icon: 'success',
          title: 'Запазени промени',
          timer: 1200,
          showConfirmButton: false,
        });
        this.loadCategories();
      },
      error: async () => {
        await Swal.fire({
          icon: 'error',
          title: 'Грешка',
          text: 'Неуспешна редакция на категория.',
        });
      },
    });
  }

  async confirmDelete(cat: CategoryDto): Promise<void> {
    const result = await Swal.fire({
      icon: 'warning',
      title: 'Изтриване на категория',
      text: `Сигурен ли си, че искаш да изтриеш „${cat.name}“?`,
      showCancelButton: true,
      confirmButtonText: 'Да, изтрий',
      cancelButtonText: 'Отказ',
    });

    if (!result.isConfirmed) return;

    this.categoriesService.delete(cat.id).subscribe({
      next: async () => {
        await Swal.fire({
          icon: 'success',
          title: 'Изтрито',
          timer: 1100,
          showConfirmButton: false,
        });

        // махаме го от списъка без да презареждаме
        this.categories = this.categories.filter((c) => c.id !== cat.id);
      },
      error: async () => {
        await Swal.fire({
          icon: 'error',
          title: 'Грешка',
          text: 'Неуспешно изтриване на категория.',
        });
      },
    });
  }
}
