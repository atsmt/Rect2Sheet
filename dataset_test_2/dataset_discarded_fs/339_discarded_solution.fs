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
        var sketch0 = newSketchOnPlane(context, id + "sketch0", { "sketchPlane" : plane(vector(172.0, 0.0, 0.0) * millimeter, vector(0.0, 0.0, -1.0), vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketch0, "poly0", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(172.000000, 0.000000) * millimeter, vector(223.000000, 147.000000) * millimeter, vector(233.000000, 147.000000) * millimeter, vector(233.000000, 204.682000) * millimeter, vector(223.000000, 204.682000) * millimeter, vector(172.000000, 197.000000) * millimeter, vector(127.568700, 223.000000) * millimeter, vector(127.568700, 233.000000) * millimeter, vector(44.431300, 233.000000) * millimeter, vector(44.431300, 223.000000) * millimeter, vector(0.000000, 197.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketch0);
        opExtractSurface(context, id + "surf0", {
            "faces" : qContainsPoint(qSketchRegion(id + "sketch0"), vector(68.798717, 114.517386, 0.000000) * millimeter),
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

        // === Child Tab 1 from 0 (one_bend) ===
        // Flange 0->1: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_1", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(86.000000, 233.000000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 1
        var sketchRem1 = newSketchOnPlane(context, id + "sketchRem1", { "sketchPlane" : plane(vector(0.0, 233.0, 61.0) * millimeter, vector(0.0, -1.0, 0.0), vector(1.0, 0.0, 0.0)) });
        skPolyline(sketchRem1, "polyRem1", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(44.431300, -51.000000) * millimeter, vector(44.431300, -59.000000) * millimeter, vector(127.568700, -59.000000) * millimeter, vector(127.568700, -51.000000) * millimeter, vector(172.000000, 0.000000) * millimeter, vector(172.000000, 155.000000) * millimeter, vector(0.000000, 155.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem1);
        sheetMetalTab(context, id + "smTab1", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1"), vector(86.000000, 233.000000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_1", EntityType.FACE), vector(86.000000, 233.000000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 2 from 0 (one_bend) ===
        // Flange 0->2: bend=90.00deg, zone=10mm
        sheetMetalFlange(context, id + "flange0_2", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(-61.000000, 175.841000, 0.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 90.000000 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 2
        var sketchRem2 = newSketchOnPlane(context, id + "sketchRem2", { "sketchPlane" : plane(vector(-61.0, 294.0, 208.0) * millimeter, vector(1.0, 0.0, 0.0), vector(0.0, 0.0, -1.0)) });
        skPolyline(sketchRem2, "polyRem2", { "points" : [vector(0.000000, 0.000000) * millimeter, vector(198.000000, -147.000000) * millimeter, vector(206.000000, -147.000000) * millimeter, vector(206.000000, -89.318000) * millimeter, vector(198.000000, -89.318000) * millimeter, vector(147.000000, 0.000000) * millimeter, vector(147.000000, 221.000000) * millimeter, vector(0.000000, 221.000000) * millimeter, vector(0.000000, 0.000000) * millimeter] });
        skSolve(sketchRem2);
        sheetMetalTab(context, id + "smTab2", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem2"), vector(-61.000000, 175.841000, 5.000000) * millimeter),
            "booleanUnionScope" : qClosestTo(qCreatedBy(id + "flange0_2", EntityType.FACE), vector(-61.000000, 175.841000, 5.000000) * millimeter),
            "booleanOffset" : 0.0 * millimeter
        });

        // === Child Tab 3 from 1 (two_bend) ===
        // Flange 1->1_1_3: bend=62.99deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_1_3a", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(86.000000, 233.000000, 218.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 62.987305 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : true
        });

        // Remaining polygon for tab 1_1_3
        var wallFace1_1_3a = qClosestTo(qCreatedBy(id + "flange1_1_1_3a", EntityType.FACE), vector(86.000000, 228.545470, 220.270940) * millimeter);
        var faceN1_1_3a = evPlane(context, { "face" : wallFace1_1_3a }).normal;
        var skN1_1_3a = dot(faceN1_1_3a, vector(0.0, 0.4541879143, 0.8909059089)) >= 0 ? faceN1_1_3a : -faceN1_1_3a;
        var sketchRem1_1_3a = newSketchOnPlane(context, id + "sketchRem1_1_3a", { "sketchPlane" : plane(vector(172.0, 224.0909, 222.5419) * millimeter, skN1_1_3a, vector(0.0, 0.8909059089, -0.4541879143)) });
        skPolyline(sketchRem1_1_3a, "polyRem1_1_3a", { "points" : [vector(8.000046, 0.000000) * millimeter, vector(8.000046, 172.000000) * millimeter, vector(-45.245041, 172.000000) * millimeter, vector(-45.245041, 0.000000) * millimeter, vector(8.000046, 0.000000) * millimeter] });
        skSolve(sketchRem1_1_3a);
        sheetMetalTab(context, id + "smTab1_1_3a", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem1_1_3a"), vector(172.000000, 228.545470, 220.270940) * millimeter),
            "booleanUnionScope" : wallFace1_1_3a,
            "booleanOffset" : 0.0 * millimeter
        });
        // Flange 1_1_3->3: bend=152.99deg, zone=10mm
        sheetMetalFlange(context, id + "flange1_1_3_3b", {
            "edges" : qClosestTo(qOwnedByBody(qBodyType(qCreatedBy(id + "smStart0", EntityType.BODY), BodyType.SOLID), EntityType.EDGE), vector(86.000000, 182.000000, 244.000000) * millimeter),
            "angleControlType" : SMFlangeAngleControlType.BEND_ANGLE,
            "bendAngle" : 152.987305 * degree,
            "limitType" : SMFlangeBoundingType.BLIND,
            "distance" : 10.000000 * millimeter,
            "flangeAlignment" : SMFlangeAlignment.BEND,
            "autoMiter" : true,
            "useDefaultRadius" : false,
            "bendRadius" : bendRadius,
            "oppositeDirection" : false
        });

        // Remaining polygon for tab 3
        var wallFace3b = qClosestTo(qCreatedBy(id + "flange1_1_3_3b", EntityType.FACE), vector(86.000000, 177.000000, 244.000000) * millimeter);
        var faceN3b = evPlane(context, { "face" : wallFace3b }).normal;
        var skN3b = dot(faceN3b, vector(0.0, 0.0, 1.0)) >= 0 ? faceN3b : -faceN3b;
        var sketchRem3b = newSketchOnPlane(context, id + "sketchRem3b", { "sketchPlane" : plane(vector(172.0, 172.0, 244.0) * millimeter, skN3b, vector(-1.0, 0.0, 0.0)) });
        skPolyline(sketchRem3b, "polyRem3b", { "points" : [vector(0.000000, -8.000000) * millimeter, vector(172.000000, -8.000000) * millimeter, vector(172.000000, 86.000000) * millimeter, vector(0.000000, 86.000000) * millimeter, vector(0.000000, -8.000000) * millimeter] });
        skSolve(sketchRem3b);
        sheetMetalTab(context, id + "smTab3b", {
            "tabFaces" : qContainsPoint(qSketchRegion(id + "sketchRem3b"), vector(86.000000, 172.000000, 244.000000) * millimeter),
            "booleanUnionScope" : wallFace3b,
            "booleanOffset" : 0.0 * millimeter
        });
    });