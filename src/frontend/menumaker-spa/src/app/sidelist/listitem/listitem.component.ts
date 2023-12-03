import { Component, Input, Output, EventEmitter  } from '@angular/core';
import { SelectedRecipe } from '../../types/appTypes';
import {MatButtonModule} from '@angular/material/button';
import { AppstateService } from '../../services/appstate.service';

@Component({
  selector: 'listitem',
  standalone: true,
  imports: [MatButtonModule],
  templateUrl: './listitem.component.html',
  styleUrl: './listitem.component.scss'
})
export class ListitemComponent {
  @Input()
  recipe : SelectedRecipe | undefined;

  @Output() 
  deleteItemEvent = new EventEmitter<number>();

  constructor(private stateService : AppstateService) {
  }

  onDeleteClicked() {
    console.log('remove ' + this.recipe?.id)
    if (this.recipe) {
      this.deleteItemEvent.emit(this.recipe.id);
    }
  }

  onPortionsChanged(event : any) {
    if (this.recipe) {
      this.stateService.changeAmountOfSelectedRecipe(this.recipe.id, event.target.value);
    }
  }
}
