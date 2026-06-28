FeatureScript 2837;
import(path : "onshape/std/geometry.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalStart.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalFlange.fs", version : "2837.0");
import(path : "onshape/std/sheetMetalTab.fs", version : "2837.0");
annotation { "Feature Type Name" : "hgen-sm-part-sm" }
export const smPart = defineFeature(function(context is Context, id is Id, definition is map)
    precondition { }
    {
        const thickness = 1.0 * millimeter;
        const bendRadius = 1.0 * millimeter;

        // === Root Tab 0 ===
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(0.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, 1.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 200.000000) * millimeter, vector(0.000000, 380.000000) * millimeter, vector(100.000000, 380.000000) * millimeter, vector(140.000000, 376.606300) * millimeter, vector(150.000000, 376.606300) * millimeter, vector(150.000000, 329.310300) * millimeter, vector(140.000000, 329.310300) * millimeter, vector(100.000000, 200.000000) * millimeter, vector(0.000000, 200.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(65.007322, 296.300440, 0.000000) * millimeter),
            "excludeFillets" : false
        });
        sheetMetalStart(context, id + "smStart0", {
            "process" : SMProcessType.CONVERT,
            "partToConvert" : qCreatedBy(id + "surf0", EntityType.BODY),
            "bends" : qNothing(),
            "facesToExclude" : qNothing(),
            "thickness" : thickness,
            "radius" : bendRadius
        });

        // === Child Tab 2 from 0 (one_bend) ===
        // Flange 0->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(150.000000, 183.980300, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 2
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(150.0, 350.0, -20.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, -1.0, 0.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(100.000000, 0.000000) * millimeter, vector(134.482800, -10.000000) * millimeter, vector(134.482800, -18.000000) * millimeter, vector(197.556600, -18.000000) * millimeter, vector(197.556600, -10.000000) * millimeter, vector(100.000000, 120.000000) * millimeter, vector(0.000000, 120.000000) * millimeter, vector(-26.606300, -10.000000) * millimeter, vector(-26.606300, -22.000000) * millimeter, vector(20.689700, -22.000000) * millimeter, vector(20.689700, -10.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(150.000000, 183.980300, -5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2", EntityType.FACE), vector(150.000000, 183.980300, -5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 0 (two_bend) ===
        // Flange 0->1_0_3: bend=6.36deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1_0_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(50.000000, 150.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 6.364299 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1_0_3
        var wallFace1_0_3a = qClosestTo(qCreatedBy(id + "flange0_1_0_3a", EntityType.FACE), vector(50.000000, 154.969186, 0.554248) * millimeter);
        var faceN1_0_3a = evPlane(context, { "face" : wallFace1_0_3a }).normal;
        var skN1_0_3a = dot(faceN1_0_3a, vector(0.0, 0.1108496858, -0.9938371834)) >= 0 ? faceN1_0_3a : -faceN1_0_3a;
        var sketchRem1_0_3a = newSketchOnPlane(context, id + "sketchRem1_0_3a", { "sketchPlane" : plane(vector(100.0, 159.9384, 1.1085) * millimeter, skN1_0_3a, vector(0.0, -0.9938371834, -0.1108496858)) });
        skPolyline(sketchRem1_0_3a, "polyRem1_0_3a", { "points" : [vector(8.000028, 0.000000) * millimeter, vector(8.000028, 100.000000) * millimeter, vector(-254.274335, 100.000000) * millimeter, vector(-254.274335, 0.000000) * millimeter, vector(8.000028, 0.000000) * millimeter] });
        skSolve(sketchRem1_0_3a);
        sheetMetalTab(context, id + "smTab1_0_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_0_3a"), vector(100.000000, 154.969186, 0.554248) * millimeter),
            "booleanUnionScope" : wallFace1_0_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_0_3->3: bend=106.67deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_0_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(50.000000, 414.633400, 29.516100) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 106.669079 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange1_0_3_3b", EntityType.FACE), vector(50.000000, 413.738978, 34.435451) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(0.0, -0.9838701158, -0.1788843068)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(0.0, 412.8446, 39.3548) * millimeter, skN3b, vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, -7.999991) * millimeter, vector(100.000000, -7.999991) * millimeter, vector(100.000000, 139.999984) * millimeter, vector(0.000000, 139.999984) * millimeter, vector(0.000000, -7.999991) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(50.000000, 412.844559, 39.354792) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });
    });