import { Component, Output, Input, EventEmitter } from '@angular/core';
import { EditIngredientModel } from '../../../../common/types/dto-types';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'edit-ingredient',
    imports: [],
    templateUrl: './edit-ingredient.component.html',
    styleUrl: './edit-ingredient.component.scss'
})
export class EditIngredientComponent {
  ingredientForm : FormGroup;

  @Input()
  ingredient : EditIngredientModel | null = null;

  @Output()
  editIngredientEvent = new EventEmitter<FormGroup>();

  constructor (private formBuilder: FormBuilder) {
    this.ingredientForm = this.formBuilder.group({
      id: [0],
      amount: [0],
      unit: [''],
      description: [''], 
      part: [ ], 
      groceryname: ['', [Validators.required]]
    });
  }

  ngOnInit(){
    if (this.ingredient == null) {
      this.ingredient = {
        amount: 0,
        unit:'g',
        description: null,
        partOfDish: null,
        grocery: ""
      }
    }

    this.ingredientForm.value.amount = this.ingredient.amount;
    this.ingredientForm.value.unit = this.ingredient.unit;
    this.ingredientForm.value.description = this.ingredient.description;
    this.ingredientForm.value.part = this.ingredient.partOfDish;
    this.ingredientForm.value.groceryname = this.ingredient.grocery;
  }
}
