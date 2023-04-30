CREATE TABLE public.entity_type (
	id int NOT NULL GENERATED ALWAYS AS IDENTITY,
	"name" varchar NOT NULL,
	CONSTRAINT entity_type_pk PRIMARY KEY (id)
);
CREATE UNIQUE INDEX entity_type_id_idx ON public.entity_type (id);

CREATE TABLE public.app (
	id int NOT NULL GENERATED ALWAYS AS IDENTITY,
	"name" varchar NOT NULL,
	CONSTRAINT app_pk PRIMARY KEY (id),
	CONSTRAINT app_un UNIQUE (id)
);

CREATE TABLE public.entity (
	type_id int4 NOT NULL,
	app_id int4 NOT NULL,
	id uuid NOT NULL,
	CONSTRAINT entity_pk PRIMARY KEY (id)
);

ALTER TABLE public.entity ADD CONSTRAINT app_id_fk FOREIGN KEY (app_id) REFERENCES public.app(id);
ALTER TABLE public.entity ADD CONSTRAINT entity_type_fk FOREIGN KEY (type_id) REFERENCES public.entity_type(id);

CREATE TABLE public.attribute_type (
	id int4 NOT NULL GENERATED ALWAYS AS IDENTITY,
	"name" varchar NOT NULL,
	CONSTRAINT attribute_type_pk PRIMARY KEY (id)
);

CREATE TABLE public."attribute" (
	id uuid NOT NULL,
	type_id int4 NOT NULL,
	entity_id uuid NOT NULL,
	CONSTRAINT attribute_pk PRIMARY KEY (id)
);

ALTER TABLE public."attribute" ADD CONSTRAINT attribute_entity_fk FOREIGN KEY (entity_id) REFERENCES public.entity(id);
ALTER TABLE public."attribute" ADD CONSTRAINT attribute_type_fk FOREIGN KEY (type_id) REFERENCES public.attribute_type(id);

CREATE TABLE public.value (
	value varchar NOT NULL,
	attribute_id uuid NOT NULL,
	entity_id uuid NOT NULL,
	CONSTRAINT value_un UNIQUE (value, attribute_id, entity_id)
);


ALTER TABLE public.value ADD CONSTRAINT value_attribute_fk FOREIGN KEY (attribute_id) REFERENCES public."attribute"(id);
ALTER TABLE public.value ADD CONSTRAINT value_entity_fk FOREIGN KEY (entity_id) REFERENCES public.entity(id);
