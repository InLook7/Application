import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-error-modal',
  imports: [
    CommonModule,
    MatIconModule
  ],
  templateUrl: './error-modal.component.html',
  styleUrl: './error-modal.component.css'
})
export class ErrorModalComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { messages: string[] },
    private dialogRef: MatDialogRef<ErrorModalComponent>
  ) {}
  
  closeModal() {
    console.log(this.data);
    this.dialogRef.close();
  }
}
