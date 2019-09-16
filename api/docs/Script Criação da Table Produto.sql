
-- Drop table

-- DROP TABLE public."Produto";

CREATE TABLE public."Produto" (
	"Id" serial NOT NULL,
	"QuantidadeDisponivel" int4 NOT NULL,
	"Nome" text NOT NULL,
	"Valor" numeric NOT NULL,
	"Categoria" text NULL,
	"Descricao" text NULL,
	"UrlFoto" text NULL,
	CONSTRAINT "PK_Produto" PRIMARY KEY ("Id")
);
