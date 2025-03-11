CREATE TABLE IF NOT EXISTS public.variant_text_embeddings (
        variant_id character varying(255), embeddings vector(768)
        ,CONSTRAINT variant_text_embeddings_pkey PRIMARY KEY (variant_id)
        ,CONSTRAINT variant_text_embeddings_fkey FOREIGN KEY (variant_id) REFERENCES public.product_variant (id)
        )