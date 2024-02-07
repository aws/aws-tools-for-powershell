/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// A Composition is an ephemeral resource that exists after this endpoint returns successfully.
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
        "The service call response (type Amazon.IVSRealTime.Model.StartCompositionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
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
        /// placed in the featured slot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Layout_Grid_FeaturedParticipantAttribute")]
        public System.String Grid_FeaturedParticipantAttribute { get; set; }
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
        /// See <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// AWS Resources</a> for details, including restrictions that apply to tags and "Tag
        /// naming limits and requirements"; Amazon IVS has no constraints on tags beyond what
        /// is documented there.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
            public System.String StageArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IVSRealTime.Model.StartCompositionResponse, StartIVSRTCompositionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Composition;
        }
        
    }
}
