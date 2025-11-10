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
using System.Threading;
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Creates a publishing destination where you can export your GuardDuty findings. Before
    /// you start exporting the findings, the destination resource must exist.
    /// </summary>
    [Cmdlet("New", "GDPublishingDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GuardDuty CreatePublishingDestination API operation.", Operation = new[] {"CreatePublishingDestination"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.CreatePublishingDestinationResponse))]
    [AWSCmdletOutput("System.String or Amazon.GuardDuty.Model.CreatePublishingDestinationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GuardDuty.Model.CreatePublishingDestinationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGDPublishingDestinationCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DestinationProperties_DestinationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the resource to publish to.</para><para>To specify an S3 bucket folder use the following format: <c>arn:aws:s3:::DOC-EXAMPLE-BUCKET/myFolder/</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationProperties_DestinationArn { get; set; }
        #endregion
        
        #region Parameter DestinationType
        /// <summary>
        /// <para>
        /// <para>The type of resource for the publishing destination. Currently only Amazon S3 buckets
        /// are supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GuardDuty.DestinationType")]
        public Amazon.GuardDuty.DestinationType DestinationType { get; set; }
        #endregion
        
        #region Parameter DetectorId
        /// <summary>
        /// <para>
        /// <para>The ID of the GuardDuty detector associated with the publishing destination.</para><para>To find the <c>detectorId</c> in the current Region, see the Settings page in the
        /// GuardDuty console, or run the <a href="https://docs.aws.amazon.com/guardduty/latest/APIReference/API_ListDetectors.html">ListDetectors</a>
        /// API.</para>
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
        public System.String DetectorId { get; set; }
        #endregion
        
        #region Parameter DestinationProperties_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key to use for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationProperties_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be added to a new publishing destination resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token for the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DestinationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.CreatePublishingDestinationResponse).
        /// Specifying the name of a property of type Amazon.GuardDuty.Model.CreatePublishingDestinationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DestinationId";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DetectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GDPublishingDestination (CreatePublishingDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.CreatePublishingDestinationResponse, NewGDPublishingDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DestinationProperties_DestinationArn = this.DestinationProperties_DestinationArn;
            context.DestinationProperties_KmsKeyArn = this.DestinationProperties_KmsKeyArn;
            context.DestinationType = this.DestinationType;
            #if MODULAR
            if (this.DestinationType == null && ParameterWasBound(nameof(this.DestinationType)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DetectorId = this.DetectorId;
            #if MODULAR
            if (this.DetectorId == null && ParameterWasBound(nameof(this.DetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GuardDuty.Model.CreatePublishingDestinationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DestinationProperties
            var requestDestinationPropertiesIsNull = true;
            request.DestinationProperties = new Amazon.GuardDuty.Model.DestinationProperties();
            System.String requestDestinationProperties_destinationProperties_DestinationArn = null;
            if (cmdletContext.DestinationProperties_DestinationArn != null)
            {
                requestDestinationProperties_destinationProperties_DestinationArn = cmdletContext.DestinationProperties_DestinationArn;
            }
            if (requestDestinationProperties_destinationProperties_DestinationArn != null)
            {
                request.DestinationProperties.DestinationArn = requestDestinationProperties_destinationProperties_DestinationArn;
                requestDestinationPropertiesIsNull = false;
            }
            System.String requestDestinationProperties_destinationProperties_KmsKeyArn = null;
            if (cmdletContext.DestinationProperties_KmsKeyArn != null)
            {
                requestDestinationProperties_destinationProperties_KmsKeyArn = cmdletContext.DestinationProperties_KmsKeyArn;
            }
            if (requestDestinationProperties_destinationProperties_KmsKeyArn != null)
            {
                request.DestinationProperties.KmsKeyArn = requestDestinationProperties_destinationProperties_KmsKeyArn;
                requestDestinationPropertiesIsNull = false;
            }
             // determine if request.DestinationProperties should be set to null
            if (requestDestinationPropertiesIsNull)
            {
                request.DestinationProperties = null;
            }
            if (cmdletContext.DestinationType != null)
            {
                request.DestinationType = cmdletContext.DestinationType;
            }
            if (cmdletContext.DetectorId != null)
            {
                request.DetectorId = cmdletContext.DetectorId;
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
        
        private Amazon.GuardDuty.Model.CreatePublishingDestinationResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.CreatePublishingDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "CreatePublishingDestination");
            try
            {
                return client.CreatePublishingDestinationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DestinationProperties_DestinationArn { get; set; }
            public System.String DestinationProperties_KmsKeyArn { get; set; }
            public Amazon.GuardDuty.DestinationType DestinationType { get; set; }
            public System.String DetectorId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GuardDuty.Model.CreatePublishingDestinationResponse, NewGDPublishingDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DestinationId;
        }
        
    }
}
