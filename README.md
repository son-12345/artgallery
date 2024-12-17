ArtGalleryAPI/
│
├── Controllers/
│   ├── ArtworksController.cs   // API cho tác phẩm nghệ thuật
│   ├── ArtistsController.cs    // API cho nghệ sĩ
│   ├── UsersController.cs      // Đăng ký, đăng nhập
│   ├── CommentsController.cs   // Bình luận
│
├── Models/
│   ├── Artwork.cs              // Model cho Artwork
│   ├── Artist.cs               // Model cho Artist
│   ├── User.cs                 // Model cho User
│   ├── Comment.cs              // Model cho Comment
│
├── Data/
│   ├── AppDbContext.cs         // DbContext cấu hình Entity Framework
│
├── Services/
│   ├── AuthService.cs          // JWT Authentication
│
├── appsettings.json            // Config DB và JWT
├── Program.cs                  // Khởi chạy app
└── Startup.cs                  // Middleware và Dependency Injection
