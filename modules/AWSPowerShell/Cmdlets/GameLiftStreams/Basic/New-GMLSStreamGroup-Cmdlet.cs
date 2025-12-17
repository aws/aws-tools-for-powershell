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
using Amazon.GameLiftStreams;
using Amazon.GameLiftStreams.Model;

namespace Amazon.PowerShell.Cmdlets.GMLS
{
    /// <summary>
    /// Stream groups manage how Amazon GameLift Streams allocates resources and handles
    /// concurrent streams, allowing you to effectively manage capacity and costs. Within
    /// a stream group, you specify an application to stream, streaming locations and their
    /// capacity, and the stream class you want to use when streaming applications to your
    /// end-users. A stream class defines the hardware configuration of the compute resources
    /// that Amazon GameLift Streams will use when streaming, such as the CPU, GPU, and memory.
    /// 
    /// 
    ///  
    /// <para>
    ///  Stream capacity represents the number of concurrent streams that can be active at
    /// a time. You set stream capacity per location, per stream group. The following capacity
    /// settings are available: 
    /// </para><ul><li><para><b>Always-on capacity</b>: This setting, if non-zero, indicates minimum streaming
    /// capacity which is allocated to you and is never released back to the service. You
    /// pay for this base level of capacity at all times, whether used or idle. 
    /// </para></li><li><para><b>Maximum capacity</b>: This indicates the maximum capacity that the service can
    /// allocate for you. Newly created streams may take a few minutes to start. Capacity
    /// is released back to the service when idle. You pay for capacity that is allocated
    /// to you until it is released. 
    /// </para></li><li><para><b>Target-idle capacity</b>: This indicates idle capacity which the service pre-allocates
    /// and holds for you in anticipation of future activity. This helps to insulate your
    /// users from capacity-allocation delays. You pay for capacity which is held in this
    /// intentional idle state. 
    /// </para></li></ul><para>
    /// Values for capacity must be whole number multiples of the tenancy value of the stream
    /// group's stream class.
    /// </para><para>
    ///  To adjust the capacity of any <c>ACTIVE</c> stream group, call <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_UpdateStreamGroup.html">UpdateStreamGroup</a>.
    /// 
    /// </para><para>
    ///  If the <c>CreateStreamGroup</c> request is successful, Amazon GameLift Streams assigns
    /// a unique ID to the stream group resource and sets the status to <c>ACTIVATING</c>.
    /// It can take a few minutes for Amazon GameLift Streams to finish creating the stream
    /// group while it searches for unallocated compute resources and provisions them. When
    /// complete, the stream group status will be <c>ACTIVE</c> and you can start stream sessions
    /// by using <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_StartStreamSession.html">StartStreamSession</a>.
    /// To check the stream group's status, call <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_GetStreamGroup.html">GetStreamGroup</a>.
    /// 
    /// </para><para>
    /// Stream groups should be recreated every 3-4 weeks to pick up important service updates
    /// and fixes. Stream groups that are older than 180 days can no longer be updated with
    /// new application associations. Stream groups expire when they are 365 days old, at
    /// which point they can no longer stream sessions. The exact expiration date is indicated
    /// by the date value in the <c>ExpiresAt</c> field.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GMLSStreamGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLiftStreams.Model.CreateStreamGroupResponse")]
    [AWSCmdlet("Calls the Amazon GameLiftStreams CreateStreamGroup API operation.", Operation = new[] {"CreateStreamGroup"}, SelectReturnType = typeof(Amazon.GameLiftStreams.Model.CreateStreamGroupResponse))]
    [AWSCmdletOutput("Amazon.GameLiftStreams.Model.CreateStreamGroupResponse",
        "This cmdlet returns an Amazon.GameLiftStreams.Model.CreateStreamGroupResponse object containing multiple properties."
    )]
    public partial class NewGMLSStreamGroupCmdlet : AmazonGameLiftStreamsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DefaultApplicationIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Amazon GameLift Streams application that you want to
        /// set as the default application in a stream group. The application that you specify
        /// must be in <c>READY</c> status. The default application is pre-cached on always-on
        /// compute resources, reducing stream startup times. Other applications are automatically
        /// cached as needed.</para><para>If you do not link an application when you create a stream group, you will need to
        /// link one later, before you can start streaming, using <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_AssociateApplications.html">AssociateApplications</a>.</para><para>This value is an <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference-arns.html">Amazon
        /// Resource Name (ARN)</a> or ID that uniquely identifies the application resource. Example
        /// ARN: <c>arn:aws:gameliftstreams:us-west-2:111122223333:application/a-9ZY8X7Wv6</c>.
        /// Example ID: <c>a-9ZY8X7Wv6</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultApplicationIdentifier { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A descriptive label for the stream group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LocationConfiguration
        /// <summary>
        /// <para>
        /// <para> A set of one or more locations and the streaming capacity for each location. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LocationConfigurations")]
        public Amazon.GameLiftStreams.Model.LocationConfiguration[] LocationConfiguration { get; set; }
        #endregion
        
        #region Parameter StreamClass
        /// <summary>
        /// <para>
        /// <para>The target stream quality for sessions that are hosted in this stream group. Set a
        /// stream class that is appropriate to the type of content that you're streaming. Stream
        /// class determines the type of computing resources Amazon GameLift Streams uses and
        /// impacts the cost of streaming. The following options are available: </para><para>A stream class can be one of the following:</para><ul><li><para><b><c>gen6n_pro_win2022</c> (NVIDIA, pro)</b> Supports applications with extremely
        /// high 3D scene complexity which require maximum resources. Runs applications on Microsoft
        /// Windows Server 2022 Base and supports DirectX 12. Compatible with Unreal Engine versions
        /// up through 5.6, 32 and 64-bit applications, and anti-cheat technology. Uses NVIDIA
        /// L4 Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 16 vCPUs, 64 GB RAM, 24 GB VRAM</para></li><li><para>Tenancy: Supports 1 concurrent stream session</para></li></ul></li><li><para><b><c>gen6n_pro</c> (NVIDIA, pro)</b> Supports applications with extremely high
        /// 3D scene complexity which require maximum resources. Uses dedicated NVIDIA L4 Tensor
        /// Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 16 vCPUs, 64 GB RAM, 24 GB VRAM</para></li><li><para>Tenancy: Supports 1 concurrent stream session</para></li></ul></li><li><para><b><c>gen6n_ultra_win2022</c> (NVIDIA, ultra)</b> Supports applications with high
        /// 3D scene complexity. Runs applications on Microsoft Windows Server 2022 Base and supports
        /// DirectX 12. Compatible with Unreal Engine versions up through 5.6, 32 and 64-bit applications,
        /// and anti-cheat technology. Uses NVIDIA L4 Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 8 vCPUs, 32 GB RAM, 24 GB VRAM</para></li><li><para>Tenancy: Supports 1 concurrent stream session</para></li></ul></li><li><para><b><c>gen6n_ultra</c> (NVIDIA, ultra)</b> Supports applications with high 3D scene
        /// complexity. Uses dedicated NVIDIA L4 Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 8 vCPUs, 32 GB RAM, 24 GB VRAM</para></li><li><para>Tenancy: Supports 1 concurrent stream session</para></li></ul></li><li><para><b><c>gen6n_high</c> (NVIDIA, high)</b> Supports applications with moderate to high
        /// 3D scene complexity. Uses NVIDIA L4 Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 4 vCPUs, 16 GB RAM, 12 GB VRAM</para></li><li><para>Tenancy: Supports up to 2 concurrent stream sessions</para></li></ul></li><li><para><b><c>gen6n_medium</c> (NVIDIA, medium)</b> Supports applications with moderate
        /// 3D scene complexity. Uses NVIDIA L4 Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 2 vCPUs, 8 GB RAM, 6 GB VRAM</para></li><li><para>Tenancy: Supports up to 4 concurrent stream sessions</para></li></ul></li><li><para><b><c>gen6n_small</c> (NVIDIA, small)</b> Supports applications with lightweight
        /// 3D scene complexity and low CPU usage. Uses NVIDIA L4 Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 1 vCPUs, 4 GB RAM, 2 GB VRAM</para></li><li><para>Tenancy: Supports up to 12 concurrent stream sessions</para></li></ul></li><li><para><b><c>gen5n_win2022</c> (NVIDIA, ultra)</b> Supports applications with extremely
        /// high 3D scene complexity. Runs applications on Microsoft Windows Server 2022 Base
        /// and supports DirectX 12. Compatible with Unreal Engine versions up through 5.6, 32
        /// and 64-bit applications, and anti-cheat technology. Uses NVIDIA A10G Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 8 vCPUs, 32 GB RAM, 24 GB VRAM</para></li><li><para>Tenancy: Supports 1 concurrent stream session</para></li></ul></li><li><para><b><c>gen5n_high</c> (NVIDIA, high)</b> Supports applications with moderate to high
        /// 3D scene complexity. Uses NVIDIA A10G Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 4 vCPUs, 16 GB RAM, 12 GB VRAM</para></li><li><para>Tenancy: Supports up to 2 concurrent stream sessions</para></li></ul></li><li><para><b><c>gen5n_ultra</c> (NVIDIA, ultra)</b> Supports applications with extremely high
        /// 3D scene complexity. Uses dedicated NVIDIA A10G Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 8 vCPUs, 32 GB RAM, 24 GB VRAM</para></li><li><para>Tenancy: Supports 1 concurrent stream session</para></li></ul></li><li><para><b><c>gen4n_win2022</c> (NVIDIA, ultra)</b> Supports applications with extremely
        /// high 3D scene complexity. Runs applications on Microsoft Windows Server 2022 Base
        /// and supports DirectX 12. Compatible with Unreal Engine versions up through 5.6, 32
        /// and 64-bit applications, and anti-cheat technology. Uses NVIDIA T4 Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 8 vCPUs, 32 GB RAM, 16 GB VRAM</para></li><li><para>Tenancy: Supports 1 concurrent stream session</para></li></ul></li><li><para><b><c>gen4n_high</c> (NVIDIA, high)</b> Supports applications with moderate to high
        /// 3D scene complexity. Uses NVIDIA T4 Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 4 vCPUs, 16 GB RAM, 8 GB VRAM</para></li><li><para>Tenancy: Supports up to 2 concurrent stream sessions</para></li></ul></li><li><para><b><c>gen4n_ultra</c> (NVIDIA, ultra)</b> Supports applications with high 3D scene
        /// complexity. Uses dedicated NVIDIA T4 Tensor Core GPU.</para><ul><li><para>Reference resolution: 1080p</para></li><li><para>Reference frame rate: 60 fps</para></li><li><para>Workload specifications: 8 vCPUs, 32 GB RAM, 16 GB VRAM</para></li><li><para>Tenancy: Supports 1 concurrent stream session</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GameLiftStreams.StreamClass")]
        public Amazon.GameLiftStreams.StreamClass StreamClass { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of labels to assign to the new stream group resource. Tags are developer-defined
        /// key-value pairs. Tagging Amazon Web Services resources is useful for resource management,
        /// access management and cost allocation. See <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">
        /// Tagging Amazon Web Services Resources</a> in the <i>Amazon Web Services General Reference</i>.
        /// You can use <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_TagResource.html">TagResource</a>
        /// to add tags, <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_UntagResource.html">UntagResource</a>
        /// to remove tags, and <a href="https://docs.aws.amazon.com/gameliftstreams/latest/apireference/API_ListTagsForResource.html">ListTagsForResource</a>
        /// to view tags on existing resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier that represents a client request. The request is idempotent,
        /// which ensures that an API request completes only once. When users send a request,
        /// Amazon GameLift Streams automatically populates this field. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLiftStreams.Model.CreateStreamGroupResponse).
        /// Specifying the name of a property of type Amazon.GameLiftStreams.Model.CreateStreamGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLSStreamGroup (CreateStreamGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLiftStreams.Model.CreateStreamGroupResponse, NewGMLSStreamGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DefaultApplicationIdentifier = this.DefaultApplicationIdentifier;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LocationConfiguration != null)
            {
                context.LocationConfiguration = new List<Amazon.GameLiftStreams.Model.LocationConfiguration>(this.LocationConfiguration);
            }
            context.StreamClass = this.StreamClass;
            #if MODULAR
            if (this.StreamClass == null && ParameterWasBound(nameof(this.StreamClass)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamClass which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLiftStreams.Model.CreateStreamGroupRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DefaultApplicationIdentifier != null)
            {
                request.DefaultApplicationIdentifier = cmdletContext.DefaultApplicationIdentifier;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.LocationConfiguration != null)
            {
                request.LocationConfigurations = cmdletContext.LocationConfiguration;
            }
            if (cmdletContext.StreamClass != null)
            {
                request.StreamClass = cmdletContext.StreamClass;
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
        
        private Amazon.GameLiftStreams.Model.CreateStreamGroupResponse CallAWSServiceOperation(IAmazonGameLiftStreams client, Amazon.GameLiftStreams.Model.CreateStreamGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLiftStreams", "CreateStreamGroup");
            try
            {
                #if DESKTOP
                return client.CreateStreamGroup(request);
                #elif CORECLR
                return client.CreateStreamGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DefaultApplicationIdentifier { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.GameLiftStreams.Model.LocationConfiguration> LocationConfiguration { get; set; }
            public Amazon.GameLiftStreams.StreamClass StreamClass { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GameLiftStreams.Model.CreateStreamGroupResponse, NewGMLSStreamGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
