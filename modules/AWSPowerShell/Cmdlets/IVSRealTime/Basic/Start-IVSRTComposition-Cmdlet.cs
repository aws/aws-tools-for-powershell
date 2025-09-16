/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.IVSRealTime;
using Amazon.IVSRealTime.Model;

namespace Amazon.PowerShell.Cmdlets.IVSRT
{
    /// <summary>
    /// Starts a Composition from a stage based on the configuration provided in the request.
    /// 
    ///  
    /// <para>
    /// A Composition is an ephemeral resource that exists after this operation returns successfully.
    /// Composition stops and the resource is deleted:
    /// </para><ul><li><para>
    /// When <a>StopComposition</a> is called.
    /// </para></li><li><para>
    /// After a 1-minute timeout, when all participants are disconnected from the stage.
    /// </para></li><li><para>
    /// After a 1-minute timeout, if there are no participants in the stage when StartComposition
    /// is called.
    /// </para></li><li><para>
    /// When broadcasting to the IVS channel fails and all retries are exhausted.
    /// </para></li><li><para>
    /// When broadcasting is disconnected and all attempts to reconnect are exhausted.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "IVSRTComposition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVSRealTime.Model.Composition")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service RealTime StartComposition API operation.", Operation = new[] {"StartComposition"}, SelectReturnType = typeof(Amazon.IVSRealTime.Model.StartCompositionResponse))]
    [AWSCmdletOutput("Amazon.IVSRealTime.Model.Composition or Amazon.IVSRealTime.Model.StartCompositionResponse",
        "This cmdlet returns an Amazon.IVSRealTime.Model.Composition object.",
        "The service call response (type Amazon.IVSRealTime.Model.StartCompositionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartIVSRTCompositionCmdlet : AmazonIVSRealTimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para>Array of destination configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Destinations")]
        public Amazon.IVSRealTime.Model.DestinationConfiguration[] Destination { get; set; }
        #endregion
        
        #region Parameter Grid_FeaturedParticipantAttribute
        /// <summary>
        /// <para>
        /// <para>This attribute name identifies the featured slot. A participant with this attribute
        /// set to <c>"true"</c> (as a string value) in <a>ParticipantTokenConfiguration</a> is
        /// placed in the featured slot. Default: <c>""</c> (no featured participant).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Grid_FeaturedParticipantAttribute")]
        public System.String Grid_FeaturedParticipantAttribute { get; set; }
        #endregion
        
        #region Parameter Pip_FeaturedParticipantAttribute
        /// <summary>
        /// <para>
        /// <para>This attribute name identifies the featured slot. A participant with this attribute
        /// set to <c>"true"</c> (as a string value) in <a>ParticipantTokenConfiguration</a> is
        /// placed in the featured slot. Default: <c>""</c> (no featured participant).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_FeaturedParticipantAttribute")]
        public System.String Pip_FeaturedParticipantAttribute { get; set; }
        #endregion
        
        #region Parameter Grid_GridGap
        /// <summary>
        /// <para>
        /// <para>Specifies the spacing between participant tiles in pixels. Default: <c>2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Grid_GridGap")]
        public System.Int32? Grid_GridGap { get; set; }
        #endregion
        
        #region Parameter Pip_GridGap
        /// <summary>
        /// <para>
        /// <para>Specifies the spacing between participant tiles in pixels. Default: <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_GridGap")]
        public System.Int32? Pip_GridGap { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter Grid_OmitStoppedVideo
        /// <summary>
        /// <para>
        /// <para>Determines whether to omit participants with stopped video in the composition. Default:
        /// <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Grid_OmitStoppedVideo")]
        public System.Boolean? Grid_OmitStoppedVideo { get; set; }
        #endregion
        
        #region Parameter Pip_OmitStoppedVideo
        /// <summary>
        /// <para>
        /// <para>Determines whether to omit participants with stopped video in the composition. Default:
        /// <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_OmitStoppedVideo")]
        public System.Boolean? Pip_OmitStoppedVideo { get; set; }
        #endregion
        
        #region Parameter Grid_ParticipantOrderAttribute
        /// <summary>
        /// <para>
        /// <para>Attribute name in <a>ParticipantTokenConfiguration</a> identifying the participant
        /// ordering key. Participants with <c>participantOrderAttribute</c> set to <c>""</c>
        /// or not specified are ordered based on their arrival time into the stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Grid_ParticipantOrderAttribute")]
        public System.String Grid_ParticipantOrderAttribute { get; set; }
        #endregion
        
        #region Parameter Pip_ParticipantOrderAttribute
        /// <summary>
        /// <para>
        /// <para>Attribute name in <a>ParticipantTokenConfiguration</a> identifying the participant
        /// ordering key. Participants with <c>participantOrderAttribute</c> set to <c>""</c>
        /// or not specified are ordered based on their arrival time into the stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_ParticipantOrderAttribute")]
        public System.String Pip_ParticipantOrderAttribute { get; set; }
        #endregion
        
        #region Parameter Pip_PipBehavior
        /// <summary>
        /// <para>
        /// <para>Defines PiP behavior when all participants have left: <c>STATIC</c> (maintains original
        /// position/size) or <c>DYNAMIC</c> (expands to full composition). Default: <c>STATIC</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_PipBehavior")]
        [AWSConstantClassSource("Amazon.IVSRealTime.PipBehavior")]
        public Amazon.IVSRealTime.PipBehavior Pip_PipBehavior { get; set; }
        #endregion
        
        #region Parameter Pip_PipHeight
        /// <summary>
        /// <para>
        /// <para>Specifies the height of the PiP window in pixels. When this is not set explicitly,
        /// <c>pipHeight</c>’s value will be based on the size of the composition and the aspect
        /// ratio of the participant’s video.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_PipHeight")]
        public System.Int32? Pip_PipHeight { get; set; }
        #endregion
        
        #region Parameter Pip_PipOffset
        /// <summary>
        /// <para>
        /// <para>Sets the PiP window’s offset position in pixels from the closest edges determined
        /// by <c>PipPosition</c>. Default: <c>0</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_PipOffset")]
        public System.Int32? Pip_PipOffset { get; set; }
        #endregion
        
        #region Parameter Pip_PipParticipantAttribute
        /// <summary>
        /// <para>
        /// <para>Specifies the participant for the PiP window. A participant with this attribute set
        /// to <c>"true"</c> (as a string value) in <a>ParticipantTokenConfiguration</a> is placed
        /// in the PiP slot. Default: <c>""</c> (no PiP participant).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_PipParticipantAttribute")]
        public System.String Pip_PipParticipantAttribute { get; set; }
        #endregion
        
        #region Parameter Pip_PipPosition
        /// <summary>
        /// <para>
        /// <para>Determines the corner position of the PiP window. Default: <c>BOTTOM_RIGHT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_PipPosition")]
        [AWSConstantClassSource("Amazon.IVSRealTime.PipPosition")]
        public Amazon.IVSRealTime.PipPosition Pip_PipPosition { get; set; }
        #endregion
        
        #region Parameter Pip_PipWidth
        /// <summary>
        /// <para>
        /// <para>Specifies the width of the PiP window in pixels. When this is not set explicitly,
        /// <c>pipWidth</c>’s value will be based on the size of the composition and the aspect
        /// ratio of the participant’s video.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_PipWidth")]
        public System.Int32? Pip_PipWidth { get; set; }
        #endregion
        
        #region Parameter StageArn
        /// <summary>
        /// <para>
        /// <para>ARN of the stage to be used for compositing.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String StageArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags attached to the resource. Array of maps, each of the form <c>string:string (key:value)</c>.
        /// See <a href="https://docs.aws.amazon.com/tag-editor/latest/userguide/best-practices-and-strats.html">Best
        /// practices and strategies</a> in <i>Tagging AWS Resources and Tag Editor</i> for details,
        /// including restrictions that apply to tags and "Tag naming limits and requirements";
        /// Amazon IVS has no constraints on tags beyond what is documented there.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Grid_VideoAspectRatio
        /// <summary>
        /// <para>
        /// <para>Sets the non-featured participant display mode, to control the aspect ratio of video
        /// tiles. <c>VIDEO</c> is 16:9, <c>SQUARE</c> is 1:1, and <c>PORTRAIT</c> is 3:4. Default:
        /// <c>VIDEO</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Grid_VideoAspectRatio")]
        [AWSConstantClassSource("Amazon.IVSRealTime.VideoAspectRatio")]
        public Amazon.IVSRealTime.VideoAspectRatio Grid_VideoAspectRatio { get; set; }
        #endregion
        
        #region Parameter Grid_VideoFillMode
        /// <summary>
        /// <para>
        /// <para>Defines how video content fits within the participant tile: <c>FILL</c> (stretched),
        /// <c>COVER</c> (cropped), or <c>CONTAIN</c> (letterboxed). When not set, <c>videoFillMode</c>
        /// defaults to <c>COVER</c> fill mode for participants in the grid and to <c>CONTAIN</c>
        /// fill mode for featured participants.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Grid_VideoFillMode")]
        [AWSConstantClassSource("Amazon.IVSRealTime.VideoFillMode")]
        public Amazon.IVSRealTime.VideoFillMode Grid_VideoFillMode { get; set; }
        #endregion
        
        #region Parameter Pip_VideoFillMode
        /// <summary>
        /// <para>
        /// <para>Defines how video content fits within the participant tile: <c>FILL</c> (stretched),
        /// <c>COVER</c> (cropped), or <c>CONTAIN</c> (letterboxed). Default: <c>COVER</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Pip_VideoFillMode")]
        [AWSConstantClassSource("Amazon.IVSRealTime.VideoFillMode")]
        public Amazon.IVSRealTime.VideoFillMode Pip_VideoFillMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Composition'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVSRealTime.Model.StartCompositionResponse).
        /// Specifying the name of a property of type Amazon.IVSRealTime.Model.StartCompositionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Composition";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StageArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StageArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StageArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StageArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IVSRTComposition (StartComposition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVSRealTime.Model.StartCompositionResponse, StartIVSRTCompositionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StageArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Destination != null)
            {
                context.Destination = new List<Amazon.IVSRealTime.Model.DestinationConfiguration>(this.Destination);
            }
            #if MODULAR
            if (this.Destination == null && ParameterWasBound(nameof(this.Destination)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdempotencyToken = this.IdempotencyToken;
            context.Grid_FeaturedParticipantAttribute = this.Grid_FeaturedParticipantAttribute;
            context.Grid_GridGap = this.Grid_GridGap;
            context.Grid_OmitStoppedVideo = this.Grid_OmitStoppedVideo;
            context.Grid_ParticipantOrderAttribute = this.Grid_ParticipantOrderAttribute;
            context.Grid_VideoAspectRatio = this.Grid_VideoAspectRatio;
            context.Grid_VideoFillMode = this.Grid_VideoFillMode;
            context.Pip_FeaturedParticipantAttribute = this.Pip_FeaturedParticipantAttribute;
            context.Pip_GridGap = this.Pip_GridGap;
            context.Pip_OmitStoppedVideo = this.Pip_OmitStoppedVideo;
            context.Pip_ParticipantOrderAttribute = this.Pip_ParticipantOrderAttribute;
            context.Pip_PipBehavior = this.Pip_PipBehavior;
            context.Pip_PipHeight = this.Pip_PipHeight;
            context.Pip_PipOffset = this.Pip_PipOffset;
            context.Pip_PipParticipantAttribute = this.Pip_PipParticipantAttribute;
            context.Pip_PipPosition = this.Pip_PipPosition;
            context.Pip_PipWidth = this.Pip_PipWidth;
            context.Pip_VideoFillMode = this.Pip_VideoFillMode;
            context.StageArn = this.StageArn;
            #if MODULAR
            if (this.StageArn == null && ParameterWasBound(nameof(this.StageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IVSRealTime.Model.StartCompositionRequest();
            
            if (cmdletContext.Destination != null)
            {
                request.Destinations = cmdletContext.Destination;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            
             // populate Layout
            var requestLayoutIsNull = true;
            request.Layout = new Amazon.IVSRealTime.Model.LayoutConfiguration();
            Amazon.IVSRealTime.Model.GridConfiguration requestLayout_layout_Grid = null;
            
             // populate Grid
            var requestLayout_layout_GridIsNull = true;
            requestLayout_layout_Grid = new Amazon.IVSRealTime.Model.GridConfiguration();
            System.String requestLayout_layout_Grid_grid_FeaturedParticipantAttribute = null;
            if (cmdletContext.Grid_FeaturedParticipantAttribute != null)
            {
                requestLayout_layout_Grid_grid_FeaturedParticipantAttribute = cmdletContext.Grid_FeaturedParticipantAttribute;
            }
            if (requestLayout_layout_Grid_grid_FeaturedParticipantAttribute != null)
            {
                requestLayout_layout_Grid.FeaturedParticipantAttribute = requestLayout_layout_Grid_grid_FeaturedParticipantAttribute;
                requestLayout_layout_GridIsNull = false;
            }
            System.Int32? requestLayout_layout_Grid_grid_GridGap = null;
            if (cmdletContext.Grid_GridGap != null)
            {
                requestLayout_layout_Grid_grid_GridGap = cmdletContext.Grid_GridGap.Value;
            }
            if (requestLayout_layout_Grid_grid_GridGap != null)
            {
                requestLayout_layout_Grid.GridGap = requestLayout_layout_Grid_grid_GridGap.Value;
                requestLayout_layout_GridIsNull = false;
            }
            System.Boolean? requestLayout_layout_Grid_grid_OmitStoppedVideo = null;
            if (cmdletContext.Grid_OmitStoppedVideo != null)
            {
                requestLayout_layout_Grid_grid_OmitStoppedVideo = cmdletContext.Grid_OmitStoppedVideo.Value;
            }
            if (requestLayout_layout_Grid_grid_OmitStoppedVideo != null)
            {
                requestLayout_layout_Grid.OmitStoppedVideo = requestLayout_layout_Grid_grid_OmitStoppedVideo.Value;
                requestLayout_layout_GridIsNull = false;
            }
            System.String requestLayout_layout_Grid_grid_ParticipantOrderAttribute = null;
            if (cmdletContext.Grid_ParticipantOrderAttribute != null)
            {
                requestLayout_layout_Grid_grid_ParticipantOrderAttribute = cmdletContext.Grid_ParticipantOrderAttribute;
            }
            if (requestLayout_layout_Grid_grid_ParticipantOrderAttribute != null)
            {
                requestLayout_layout_Grid.ParticipantOrderAttribute = requestLayout_layout_Grid_grid_ParticipantOrderAttribute;
                requestLayout_layout_GridIsNull = false;
            }
            Amazon.IVSRealTime.VideoAspectRatio requestLayout_layout_Grid_grid_VideoAspectRatio = null;
            if (cmdletContext.Grid_VideoAspectRatio != null)
            {
                requestLayout_layout_Grid_grid_VideoAspectRatio = cmdletContext.Grid_VideoAspectRatio;
            }
            if (requestLayout_layout_Grid_grid_VideoAspectRatio != null)
            {
                requestLayout_layout_Grid.VideoAspectRatio = requestLayout_layout_Grid_grid_VideoAspectRatio;
                requestLayout_layout_GridIsNull = false;
            }
            Amazon.IVSRealTime.VideoFillMode requestLayout_layout_Grid_grid_VideoFillMode = null;
            if (cmdletContext.Grid_VideoFillMode != null)
            {
                requestLayout_layout_Grid_grid_VideoFillMode = cmdletContext.Grid_VideoFillMode;
            }
            if (requestLayout_layout_Grid_grid_VideoFillMode != null)
            {
                requestLayout_layout_Grid.VideoFillMode = requestLayout_layout_Grid_grid_VideoFillMode;
                requestLayout_layout_GridIsNull = false;
            }
             // determine if requestLayout_layout_Grid should be set to null
            if (requestLayout_layout_GridIsNull)
            {
                requestLayout_layout_Grid = null;
            }
            if (requestLayout_layout_Grid != null)
            {
                request.Layout.Grid = requestLayout_layout_Grid;
                requestLayoutIsNull = false;
            }
            Amazon.IVSRealTime.Model.PipConfiguration requestLayout_layout_Pip = null;
            
             // populate Pip
            var requestLayout_layout_PipIsNull = true;
            requestLayout_layout_Pip = new Amazon.IVSRealTime.Model.PipConfiguration();
            System.String requestLayout_layout_Pip_pip_FeaturedParticipantAttribute = null;
            if (cmdletContext.Pip_FeaturedParticipantAttribute != null)
            {
                requestLayout_layout_Pip_pip_FeaturedParticipantAttribute = cmdletContext.Pip_FeaturedParticipantAttribute;
            }
            if (requestLayout_layout_Pip_pip_FeaturedParticipantAttribute != null)
            {
                requestLayout_layout_Pip.FeaturedParticipantAttribute = requestLayout_layout_Pip_pip_FeaturedParticipantAttribute;
                requestLayout_layout_PipIsNull = false;
            }
            System.Int32? requestLayout_layout_Pip_pip_GridGap = null;
            if (cmdletContext.Pip_GridGap != null)
            {
                requestLayout_layout_Pip_pip_GridGap = cmdletContext.Pip_GridGap.Value;
            }
            if (requestLayout_layout_Pip_pip_GridGap != null)
            {
                requestLayout_layout_Pip.GridGap = requestLayout_layout_Pip_pip_GridGap.Value;
                requestLayout_layout_PipIsNull = false;
            }
            System.Boolean? requestLayout_layout_Pip_pip_OmitStoppedVideo = null;
            if (cmdletContext.Pip_OmitStoppedVideo != null)
            {
                requestLayout_layout_Pip_pip_OmitStoppedVideo = cmdletContext.Pip_OmitStoppedVideo.Value;
            }
            if (requestLayout_layout_Pip_pip_OmitStoppedVideo != null)
            {
                requestLayout_layout_Pip.OmitStoppedVideo = requestLayout_layout_Pip_pip_OmitStoppedVideo.Value;
                requestLayout_layout_PipIsNull = false;
            }
            System.String requestLayout_layout_Pip_pip_ParticipantOrderAttribute = null;
            if (cmdletContext.Pip_ParticipantOrderAttribute != null)
            {
                requestLayout_layout_Pip_pip_ParticipantOrderAttribute = cmdletContext.Pip_ParticipantOrderAttribute;
            }
            if (requestLayout_layout_Pip_pip_ParticipantOrderAttribute != null)
            {
                requestLayout_layout_Pip.ParticipantOrderAttribute = requestLayout_layout_Pip_pip_ParticipantOrderAttribute;
                requestLayout_layout_PipIsNull = false;
            }
            Amazon.IVSRealTime.PipBehavior requestLayout_layout_Pip_pip_PipBehavior = null;
            if (cmdletContext.Pip_PipBehavior != null)
            {
                requestLayout_layout_Pip_pip_PipBehavior = cmdletContext.Pip_PipBehavior;
            }
            if (requestLayout_layout_Pip_pip_PipBehavior != null)
            {
                requestLayout_layout_Pip.PipBehavior = requestLayout_layout_Pip_pip_PipBehavior;
                requestLayout_layout_PipIsNull = false;
            }
            System.Int32? requestLayout_layout_Pip_pip_PipHeight = null;
            if (cmdletContext.Pip_PipHeight != null)
            {
                requestLayout_layout_Pip_pip_PipHeight = cmdletContext.Pip_PipHeight.Value;
            }
            if (requestLayout_layout_Pip_pip_PipHeight != null)
            {
                requestLayout_layout_Pip.PipHeight = requestLayout_layout_Pip_pip_PipHeight.Value;
                requestLayout_layout_PipIsNull = false;
            }
            System.Int32? requestLayout_layout_Pip_pip_PipOffset = null;
            if (cmdletContext.Pip_PipOffset != null)
            {
                requestLayout_layout_Pip_pip_PipOffset = cmdletContext.Pip_PipOffset.Value;
            }
            if (requestLayout_layout_Pip_pip_PipOffset != null)
            {
                requestLayout_layout_Pip.PipOffset = requestLayout_layout_Pip_pip_PipOffset.Value;
                requestLayout_layout_PipIsNull = false;
            }
            System.String requestLayout_layout_Pip_pip_PipParticipantAttribute = null;
            if (cmdletContext.Pip_PipParticipantAttribute != null)
            {
                requestLayout_layout_Pip_pip_PipParticipantAttribute = cmdletContext.Pip_PipParticipantAttribute;
            }
            if (requestLayout_layout_Pip_pip_PipParticipantAttribute != null)
            {
                requestLayout_layout_Pip.PipParticipantAttribute = requestLayout_layout_Pip_pip_PipParticipantAttribute;
                requestLayout_layout_PipIsNull = false;
            }
            Amazon.IVSRealTime.PipPosition requestLayout_layout_Pip_pip_PipPosition = null;
            if (cmdletContext.Pip_PipPosition != null)
            {
                requestLayout_layout_Pip_pip_PipPosition = cmdletContext.Pip_PipPosition;
            }
            if (requestLayout_layout_Pip_pip_PipPosition != null)
            {
                requestLayout_layout_Pip.PipPosition = requestLayout_layout_Pip_pip_PipPosition;
                requestLayout_layout_PipIsNull = false;
            }
            System.Int32? requestLayout_layout_Pip_pip_PipWidth = null;
            if (cmdletContext.Pip_PipWidth != null)
            {
                requestLayout_layout_Pip_pip_PipWidth = cmdletContext.Pip_PipWidth.Value;
            }
            if (requestLayout_layout_Pip_pip_PipWidth != null)
            {
                requestLayout_layout_Pip.PipWidth = requestLayout_layout_Pip_pip_PipWidth.Value;
                requestLayout_layout_PipIsNull = false;
            }
            Amazon.IVSRealTime.VideoFillMode requestLayout_layout_Pip_pip_VideoFillMode = null;
            if (cmdletContext.Pip_VideoFillMode != null)
            {
                requestLayout_layout_Pip_pip_VideoFillMode = cmdletContext.Pip_VideoFillMode;
            }
            if (requestLayout_layout_Pip_pip_VideoFillMode != null)
            {
                requestLayout_layout_Pip.VideoFillMode = requestLayout_layout_Pip_pip_VideoFillMode;
                requestLayout_layout_PipIsNull = false;
            }
             // determine if requestLayout_layout_Pip should be set to null
            if (requestLayout_layout_PipIsNull)
            {
                requestLayout_layout_Pip = null;
            }
            if (requestLayout_layout_Pip != null)
            {
                request.Layout.Pip = requestLayout_layout_Pip;
                requestLayoutIsNull = false;
            }
             // determine if request.Layout should be set to null
            if (requestLayoutIsNull)
            {
                request.Layout = null;
            }
            if (cmdletContext.StageArn != null)
            {
                request.StageArn = cmdletContext.StageArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IVSRealTime.Model.StartCompositionResponse CallAWSServiceOperation(IAmazonIVSRealTime client, Amazon.IVSRealTime.Model.StartCompositionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service RealTime", "StartComposition");
            try
            {
                #if DESKTOP
                return client.StartComposition(request);
                #elif CORECLR
                return client.StartCompositionAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<Amazon.IVSRealTime.Model.DestinationConfiguration> Destination { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String Grid_FeaturedParticipantAttribute { get; set; }
            public System.Int32? Grid_GridGap { get; set; }
            public System.Boolean? Grid_OmitStoppedVideo { get; set; }
            public System.String Grid_ParticipantOrderAttribute { get; set; }
            public Amazon.IVSRealTime.VideoAspectRatio Grid_VideoAspectRatio { get; set; }
            public Amazon.IVSRealTime.VideoFillMode Grid_VideoFillMode { get; set; }
            public System.String Pip_FeaturedParticipantAttribute { get; set; }
            public System.Int32? Pip_GridGap { get; set; }
            public System.Boolean? Pip_OmitStoppedVideo { get; set; }
            public System.String Pip_ParticipantOrderAttribute { get; set; }
            public Amazon.IVSRealTime.PipBehavior Pip_PipBehavior { get; set; }
            public System.Int32? Pip_PipHeight { get; set; }
            public System.Int32? Pip_PipOffset { get; set; }
            public System.String Pip_PipParticipantAttribute { get; set; }
            public Amazon.IVSRealTime.PipPosition Pip_PipPosition { get; set; }
            public System.Int32? Pip_PipWidth { get; set; }
            public Amazon.IVSRealTime.VideoFillMode Pip_VideoFillMode { get; set; }
            public System.String StageArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IVSRealTime.Model.StartCompositionResponse, StartIVSRTCompositionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Composition;
        }
        
    }
}
