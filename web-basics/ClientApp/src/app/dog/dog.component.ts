import { Component, OnInit } from '@angular/core';
import { DogService } from './dog.service';
import { Dog } from './dog';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cat',
  templateUrl: './dog.component.html',
  styleUrls: ['./dog.component.css']
})
export class DogComponent implements OnInit {

  constructor(private dogService: DogService) { }

  public dogs: Dog[];
  public form = new FormGroup({
    name: new FormControl(null, Validators.required),
    age: new FormControl(null, Validators.required),
    weight: new FormControl(null, Validators.required)
  });

  public onSubmit(): void {
    if (this.form.valid) {
      this.dogService.post(this.form.value).subscribe(() => {
        this.form.reset();
        this.updateTable();
      });
      return;
    }

    this.form.markAllAsTouched();
  }

  private updateTable(): void {
    this.dogService.get().subscribe(data => {
      this.dogs = data;
    });
  }

  ngOnInit() {
    this.updateTable();
  }

}
