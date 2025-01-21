import { Component, inject, OnInit, ChangeDetectorRef } from '@angular/core';
import { AdminService } from '../../_services/admin.service';
import { Photo } from '../../_models/Photo';

@Component({
  selector: 'app-photo-management',
  imports: [],
  templateUrl: './photo-management.component.html',
  styleUrl: './photo-management.component.css'
})
export class PhotoManagementComponent implements OnInit {
  photos: Photo[] = [];
  private adminService = inject(AdminService);
  constructor(private cdr: ChangeDetectorRef) {}
  
  ngOnInit(): void {
    this.getPhotosForApproval();
  }
  getPhotosForApproval() {
    this.adminService.getPhotosForApproval().subscribe({
      next: photos => this.photos = photos
    })
  }
  approvePhoto(photoId: number) {
    this.adminService.approvePhoto(photoId).subscribe({
      next: () => this.photos.splice(this.photos.findIndex(p => p.id ===
        photoId), 1)
    })
  }
  rejectPhoto(photoId: number) {
    this.adminService.rejectPhoto(photoId).subscribe({
      next: () => this.photos.splice(this.photos.findIndex(p => p.id ===
        photoId), 1)
    })
  }
}
