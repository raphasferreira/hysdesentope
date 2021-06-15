import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { Observable, of, ReplaySubject } from 'rxjs';
import { filter } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { TableColumn } from '../../../../@vex/interfaces/table-column.interface';
import { aioTableData, aioTableLabels } from '../../../../static-data/aio-table-data';
import icEdit from '@iconify/icons-ic/twotone-edit';
import icDelete from '@iconify/icons-ic/twotone-delete';
import icSearch from '@iconify/icons-ic/twotone-search';
import icAdd from '@iconify/icons-ic/twotone-add';
import icFilterList from '@iconify/icons-ic/twotone-filter-list';
import { SelectionModel } from '@angular/cdk/collections';
import icMoreHoriz from '@iconify/icons-ic/twotone-more-horiz';
import icFolder from '@iconify/icons-ic/twotone-folder';
import { fadeInUp400ms } from '../../../../@vex/animations/fade-in-up.animation';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS, MatFormFieldDefaultOptions } from '@angular/material/form-field';
import { stagger40ms } from '../../../../@vex/animations/stagger.animation';
import { FormControl } from '@angular/forms';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { MatSelectChange } from '@angular/material/select';
import icPhone from '@iconify/icons-ic/twotone-phone';
import icMail from '@iconify/icons-ic/twotone-mail';
import icMap from '@iconify/icons-ic/twotone-map';
import { Venda } from './interfaces/venda.model';
import { VendasCreateUpdateComponent } from './vendas-create-update/vendas-create-update.component';


@UntilDestroy()
@Component({
  selector: 'vex-vendas',
  templateUrl: './vendas.component.html',
  styleUrls: ['./vendas.component.scss'],
  animations: [
    fadeInUp400ms,
    stagger40ms
  ],
  providers: [
    {
      provide: MAT_FORM_FIELD_DEFAULT_OPTIONS,
      useValue: {
        appearance: 'standard'
      } as MatFormFieldDefaultOptions
    }
  ]
})
export class VendasComponent implements OnInit, AfterViewInit {

  layoutCtrl = new FormControl('fullwidth');

  /**
   * Simulating a service with HTTP that returns Observables
   * You probably want to remove this and do all requests in a service with HTTP
   */
  subject$: ReplaySubject<Venda[]> = new ReplaySubject<Venda[]>(1);
  data$: Observable<Venda[]> = this.subject$.asObservable();
  vendas: Venda[];

  @Input()
  columns: TableColumn<Venda>[] = [
    { label: 'Checkbox', property: 'checkbox', type: 'checkbox', visible: true },
    { label: 'Endidade', property: 'name', type: 'text', visible: true, cssClasses: ['font-medium'] },
    { label: 'Ano', property: 'firstName', type: 'text', visible: false },
    { label: 'Mês', property: 'lastName', type: 'text', visible: false },
    { label: 'Líquido', property: 'contact', type: 'button', visible: true },
    { label: 'Imposto', property: 'address', type: 'text', visible: true, cssClasses: ['text-secondary', 'font-medium'] },
    { label: 'Total', property: 'street', type: 'text', visible: false, cssClasses: ['text-secondary', 'font-medium'] },
    { label: 'Margem', property: 'zipcode', type: 'text', visible: false, cssClasses: ['text-secondary', 'font-medium'] },
    { label: 'City', property: 'city', type: 'text', visible: false, cssClasses: ['text-secondary', 'font-medium'] },
    { label: 'Phone', property: 'phoneNumber', type: 'text', visible: true, cssClasses: ['text-secondary', 'font-medium'] },
    { label: 'Labels', property: 'labels', type: 'button', visible: true },
    { label: 'Actions', property: 'actions', type: 'button', visible: true }
  ];
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 20, 50];
  dataSource: MatTableDataSource<Venda> | null;
  selection = new SelectionModel<Venda>(true, []);
  searchCtrl = new FormControl();

  labels = aioTableLabels;

  icPhone = icPhone;
  icMail = icMail;
  icMap = icMap;
  icEdit = icEdit;
  icSearch = icSearch;
  icDelete = icDelete;
  icAdd = icAdd;
  icFilterList = icFilterList;
  icMoreHoriz = icMoreHoriz;
  icFolder = icFolder;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor(private dialog: MatDialog) {
  }

  get visibleColumns() {
    return this.columns.filter(column => column.visible).map(column => column.property);
  }

  /**
   * Example on how to get data and pass it to the table - usually you would want a dedicated service with a HTTP request for this
   * We are simulating this request here.
   */
  getData() {
    return of(aioTableData.map(venda => new Venda(venda)));
  }

  ngOnInit() {
    this.getData().subscribe(vendas => {
      this.subject$.next(vendas);
    });

    this.dataSource = new MatTableDataSource();

    this.data$.pipe(
      filter<Venda[]>(Boolean)
    ).subscribe(vendas => {
      this.vendas = vendas;
      this.dataSource.data = vendas;
    });

    this.searchCtrl.valueChanges.pipe(
      untilDestroyed(this)
    ).subscribe(value => this.onFilterChange(value));
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  createVenda() {
    this.dialog.open(VendasCreateUpdateComponent).afterClosed().subscribe((venda: Venda) => {
      /**
       * Customer is the updated customer (if the user pressed Save - otherwise it's null)
       */
      if (venda) {
        /**
         * Here we are updating our local array.
         * You would probably make an HTTP request here.
         */
        this.vendas.unshift(new Venda(venda));
        this.subject$.next(this.vendas);
      }
    });
  }

  updateVenda(venda: Venda) {
    this.dialog.open(VendasCreateUpdateComponent, {
      data: venda
    }).afterClosed().subscribe(updatedVenda => {
      /**
       * Venda is the updated Venda (if the user pressed Save - otherwise it's null)
       */
      if (updatedVenda) {
        /**
         * Here we are updating our local array.
         * You would probably make an HTTP request here.
         */
        const index = this.vendas.findIndex((existingVenda) => existingVenda.id === updatedVenda.id);
        this.vendas[index] = new Venda(updatedVenda);
        this.subject$.next(this.vendas);
      }
    });
  }

  deleteVenda(venda: Venda) {
    /**
     * Here we are updating our local array.
     * You would probably make an HTTP request here.
     */
    this.vendas.splice(this.vendas.findIndex((existingCustomer) => existingCustomer.id === venda.id), 1);
    this.selection.deselect(venda);
    this.subject$.next(this.vendas);
  }

  deleteVendas(vendas: Venda[]) {
    /**
     * Here we are updating our local array.
     * You would probably make an HTTP request here.
     */
    vendas.forEach(c => this.deleteVenda(c));
  }

  onFilterChange(value: string) {
    if (!this.dataSource) {
      return;
    }
    value = value.trim();
    value = value.toLowerCase();
    this.dataSource.filter = value;
  }

  toggleColumnVisibility(column, event) {
    event.stopPropagation();
    event.stopImmediatePropagation();
    column.visible = !column.visible;
  }

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
      this.selection.clear() :
      this.dataSource.data.forEach(row => this.selection.select(row));
  }

  trackByProperty<T>(index: number, column: TableColumn<T>) {
    return column.property;
  }

  onLabelChange(change: MatSelectChange, row: Venda) {
    const index = this.vendas.findIndex(c => c === row);
    this.vendas[index].labels = change.value;
    this.subject$.next(this.vendas);
  }
}

