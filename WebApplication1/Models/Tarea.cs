﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Tarea
    {
        public Guid TareaId {  get; set; }

        [ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Titulo {  get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion {  get; set; }

       
        public Prioridad PrioridadTarea { get; set; }

      
        public DateTime FechaCreacion {  get; set; }

        public virtual Categoria Categoria { get; set; }

        [NotMapped]
        public string Resumen { get; set; }

    }


    public enum Prioridad
    {
       Baja,
       
       Media,

       Alta
    }
}
