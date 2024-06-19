PGDMP  (                    |            optativo    16.2    16.2 .               0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16409    optativo    DATABASE     ~   CREATE DATABASE optativo WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Paraguay.1252';
    DROP DATABASE optativo;
                postgres    false            �            1259    16446    cliente    TABLE     M  CREATE TABLE public.cliente (
    id integer NOT NULL,
    id_banco integer NOT NULL,
    nombre character varying(30),
    apellido character varying(30),
    documento character varying(30),
    direccion character varying(50),
    mail character varying(50),
    celular character varying(20),
    estado character varying(20)
);
    DROP TABLE public.cliente;
       public         heap    postgres    false            �            1259    16445    cliente_id_banco_seq    SEQUENCE     �   CREATE SEQUENCE public.cliente_id_banco_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 +   DROP SEQUENCE public.cliente_id_banco_seq;
       public          postgres    false    219                       0    0    cliente_id_banco_seq    SEQUENCE OWNED BY     M   ALTER SEQUENCE public.cliente_id_banco_seq OWNED BY public.cliente.id_banco;
          public          postgres    false    218            �            1259    16444    cliente_id_seq    SEQUENCE     �   CREATE SEQUENCE public.cliente_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.cliente_id_seq;
       public          postgres    false    219                       0    0    cliente_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.cliente_id_seq OWNED BY public.cliente.id;
          public          postgres    false    217            �            1259    16584    detalle_factura    TABLE     �   CREATE TABLE public.detalle_factura (
    id integer NOT NULL,
    id_factura integer NOT NULL,
    id_producto integer NOT NULL,
    cantidad_producto numeric(30,2) NOT NULL,
    subtotal numeric(30,2) NOT NULL
);
 #   DROP TABLE public.detalle_factura;
       public         heap    postgres    false            �            1259    16583    detalle_factura_id_seq    SEQUENCE     �   CREATE SEQUENCE public.detalle_factura_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.detalle_factura_id_seq;
       public          postgres    false    223                       0    0    detalle_factura_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.detalle_factura_id_seq OWNED BY public.detalle_factura.id;
          public          postgres    false    222            �            1259    16420    factura    TABLE     �  CREATE TABLE public.factura (
    id_factura integer NOT NULL,
    id_cliente integer,
    nro_factura character varying(50),
    fecha_hora timestamp without time zone,
    total numeric(30,2),
    total_iva5 numeric(30,2),
    total_iva10 numeric(30,2),
    total_iva numeric(30,2),
    total_letras character varying(100),
    sucursal character varying(100),
    id_sucursal integer
);
    DROP TABLE public.factura;
       public         heap    postgres    false            �            1259    16419    factura_id_factura_seq    SEQUENCE     �   CREATE SEQUENCE public.factura_id_factura_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.factura_id_factura_seq;
       public          postgres    false    216                       0    0    factura_id_factura_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.factura_id_factura_seq OWNED BY public.factura.id_factura;
          public          postgres    false    215            �            1259    16591    producto    TABLE     �  CREATE TABLE public.producto (
    id integer NOT NULL,
    descripcion character varying(150) NOT NULL,
    cantidad_minima numeric(40,2) NOT NULL,
    cantidad_stock numeric(40,2) NOT NULL,
    precio_compra integer NOT NULL,
    precio_venta integer NOT NULL,
    categoria character varying(150) NOT NULL,
    marca character varying(150) NOT NULL,
    estado character varying(150) NOT NULL
);
    DROP TABLE public.producto;
       public         heap    postgres    false            �            1259    16590    productos_id_seq    SEQUENCE     �   CREATE SEQUENCE public.productos_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.productos_id_seq;
       public          postgres    false    225                       0    0    productos_id_seq    SEQUENCE OWNED BY     D   ALTER SEQUENCE public.productos_id_seq OWNED BY public.producto.id;
          public          postgres    false    224            �            1259    16535    sucursal    TABLE       CREATE TABLE public.sucursal (
    id integer NOT NULL,
    descripcion character varying(200),
    direccion character varying(200),
    telefono character varying(30),
    whatsapp character varying(30),
    mail character varying(50),
    estado character varying(20)
);
    DROP TABLE public.sucursal;
       public         heap    postgres    false            �            1259    16534    sucursal_id_seq    SEQUENCE     �   CREATE SEQUENCE public.sucursal_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.sucursal_id_seq;
       public          postgres    false    221                       0    0    sucursal_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.sucursal_id_seq OWNED BY public.sucursal.id;
          public          postgres    false    220            f           2604    16449 
   cliente id    DEFAULT     h   ALTER TABLE ONLY public.cliente ALTER COLUMN id SET DEFAULT nextval('public.cliente_id_seq'::regclass);
 9   ALTER TABLE public.cliente ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    219    217    219            h           2604    16587    detalle_factura id    DEFAULT     x   ALTER TABLE ONLY public.detalle_factura ALTER COLUMN id SET DEFAULT nextval('public.detalle_factura_id_seq'::regclass);
 A   ALTER TABLE public.detalle_factura ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    223    222    223            e           2604    16423    factura id_factura    DEFAULT     x   ALTER TABLE ONLY public.factura ALTER COLUMN id_factura SET DEFAULT nextval('public.factura_id_factura_seq'::regclass);
 A   ALTER TABLE public.factura ALTER COLUMN id_factura DROP DEFAULT;
       public          postgres    false    215    216    216            i           2604    16594    producto id    DEFAULT     k   ALTER TABLE ONLY public.producto ALTER COLUMN id SET DEFAULT nextval('public.productos_id_seq'::regclass);
 :   ALTER TABLE public.producto ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    225    224    225            g           2604    16538    sucursal id    DEFAULT     j   ALTER TABLE ONLY public.sucursal ALTER COLUMN id SET DEFAULT nextval('public.sucursal_id_seq'::regclass);
 :   ALTER TABLE public.sucursal ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    220    221    221                      0    16446    cliente 
   TABLE DATA           n   COPY public.cliente (id, id_banco, nombre, apellido, documento, direccion, mail, celular, estado) FROM stdin;
    public          postgres    false    219   U6                 0    16584    detalle_factura 
   TABLE DATA           c   COPY public.detalle_factura (id, id_factura, id_producto, cantidad_producto, subtotal) FROM stdin;
    public          postgres    false    223   q7                 0    16420    factura 
   TABLE DATA           �   COPY public.factura (id_factura, id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal, id_sucursal) FROM stdin;
    public          postgres    false    216   �7                 0    16591    producto 
   TABLE DATA           �   COPY public.producto (id, descripcion, cantidad_minima, cantidad_stock, precio_compra, precio_venta, categoria, marca, estado) FROM stdin;
    public          postgres    false    225   :                 0    16535    sucursal 
   TABLE DATA           `   COPY public.sucursal (id, descripcion, direccion, telefono, whatsapp, mail, estado) FROM stdin;
    public          postgres    false    221   6;                  0    0    cliente_id_banco_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public.cliente_id_banco_seq', 1, true);
          public          postgres    false    218                       0    0    cliente_id_seq    SEQUENCE SET     <   SELECT pg_catalog.setval('public.cliente_id_seq', 6, true);
          public          postgres    false    217                        0    0    detalle_factura_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.detalle_factura_id_seq', 14, true);
          public          postgres    false    222            !           0    0    factura_id_factura_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.factura_id_factura_seq', 19, true);
          public          postgres    false    215            "           0    0    productos_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.productos_id_seq', 7, true);
          public          postgres    false    224            #           0    0    sucursal_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.sucursal_id_seq', 5, false);
          public          postgres    false    220            m           2606    16454    cliente clienteKEY 
   CONSTRAINT     R   ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT "clienteKEY" PRIMARY KEY (id);
 >   ALTER TABLE ONLY public.cliente DROP CONSTRAINT "clienteKEY";
       public            postgres    false    219            k           2606    16425    factura factura_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT factura_pkey PRIMARY KEY (id_factura);
 >   ALTER TABLE ONLY public.factura DROP CONSTRAINT factura_pkey;
       public            postgres    false    216            q           2606    16618    detalle_factura id 
   CONSTRAINT     ]   ALTER TABLE ONLY public.detalle_factura
    ADD CONSTRAINT id PRIMARY KEY (id) INCLUDE (id);
 <   ALTER TABLE ONLY public.detalle_factura DROP CONSTRAINT id;
       public            postgres    false    223            s           2606    16598    producto productos_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.producto
    ADD CONSTRAINT productos_pkey PRIMARY KEY (id);
 A   ALTER TABLE ONLY public.producto DROP CONSTRAINT productos_pkey;
       public            postgres    false    225            o           2606    16542    sucursal sucursal_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.sucursal
    ADD CONSTRAINT sucursal_pkey PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.sucursal DROP CONSTRAINT sucursal_pkey;
       public            postgres    false    221            t           2606    16479    factura id_cliente    FK CONSTRAINT     �   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT id_cliente FOREIGN KEY (id_cliente) REFERENCES public.cliente(id) NOT VALID;
 <   ALTER TABLE ONLY public.factura DROP CONSTRAINT id_cliente;
       public          postgres    false    216    219    4717            v           2606    16612    detalle_factura id_factura    FK CONSTRAINT     �   ALTER TABLE ONLY public.detalle_factura
    ADD CONSTRAINT id_factura FOREIGN KEY (id_factura) REFERENCES public.factura(id_factura) ON DELETE CASCADE NOT VALID;
 D   ALTER TABLE ONLY public.detalle_factura DROP CONSTRAINT id_factura;
       public          postgres    false    216    223    4715            w           2606    16599    detalle_factura id_producto    FK CONSTRAINT     �   ALTER TABLE ONLY public.detalle_factura
    ADD CONSTRAINT id_producto FOREIGN KEY (id_producto) REFERENCES public.producto(id) NOT VALID;
 E   ALTER TABLE ONLY public.detalle_factura DROP CONSTRAINT id_producto;
       public          postgres    false    4723    225    223            u           2606    16543    factura id_sucursal    FK CONSTRAINT     �   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT id_sucursal FOREIGN KEY (id_sucursal) REFERENCES public.sucursal(id) NOT VALID;
 =   ALTER TABLE ONLY public.factura DROP CONSTRAINT id_sucursal;
       public          postgres    false    216    4719    221                 x�]��n�0��};q��@h�6�	��.Y��[WEo�3�b�hcW�����b���t�Uɨ��k7ɗ�������ڮ	/-�� �H
�!:����h�eX�O7���KK/�]���蠽�]��?�d��~Ybx\��$8�e����N^���Zk�ͱ2�gu%�M���5�3�@�L.��F҆m1�ݸ��g��i��Ќ��jX /���������ź�0q��kɑ���W�D&�����$˲oW>w�         L   x�=���0D��P��fb����FO_$0�<��p^ڐ�Tm>�Ŷ/V��?�FO�J�EE�R�� ��H$         '  x�}�Mn�0���)x�!����e�M�]6�"b��� ��;���:ɂƈ���fH#P �^)�TJ!(�
M�t��T�H4j� �q�� ��[� ХxZ�����t��V���#_��_��6�y��8�%������C�i�Ք�:��FC�����J���ȕ�TvY�<�oU�9r�Eܯ�z�~�+��K
��LKYT��LU@=�T�*@��,�`�ʡx,;�N�(�2mUH�OYȏ%N9 �=rXIqK�L��r~� I��:	���i"��nv		����iy�K��䜧 
5�iR�@	����jIkwc�}�L��.vN�������V�@"�^!B-�i���-�ǯ�7�t�SҘ���!@�+���$2[�^�FDU,�:��qۜo�m�`�e�ا����2���NH�fQ�Lې���u�!14,q>��3�۔�q��{E�a�鶰c�6���w�%��S�Qc�HCħ&$n-]�����k]Զ��fڗ�r��%�a����3� ^��N�S��Bngڗ���ﺮ��D�         "  x�U��N�0�ϛ��T��SrD���� '.g!n�	B<=^�H�edɞog�
�U��Z'��fB�wy�d-�<j�Xo�g�7-|�L��dzK��?d�.U%�C�^�ގ�LS@8Q����Z��:�@ŉ>=�J�Z�M��Xsxq3��y3����/Nt4;��o'��(�I�BV�(���Y���&NG�#EVО.8`�*a�k0�T�»Q/gO������F�O�y��ڔ)G���խ��q�~�c�贳���I��=����_�BȒ�[����.v�y�eY�L�c         �   x�u�=n�0��>�N X�;���[ۥ�օ�ـ@$��1���N������@*���%v�4�;4��I��=b (�m�t�i���}-�q�!u'�|��[�M�������B�J��,K �K�P��������G�	E?�ؠC������Y�ט��!�Q(�n�n�zbr�;�"�
=U�J$>�Ha������m�\2iS�J�"���w|��dQ��y�     