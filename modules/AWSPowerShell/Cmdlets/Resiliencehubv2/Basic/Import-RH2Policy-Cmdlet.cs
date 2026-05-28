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
using Amazon.Resiliencehubv2;
using Amazon.Resiliencehubv2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RH2
{
    /// <summary>
    /// Imports a V1 policy into V2, mapping RTO/RPO values from V1 scenarios.
    /// </summary>
    [Cmdlet("Import", "RH2Policy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Resiliencehubv2.Model.Policy")]
    [AWSCmdlet("Calls the AWS Resilience Hub V2 ImportPolicy API operation.", Operation = new[] {"ImportPolicy"}, SelectReturnType = typeof(Amazon.Resiliencehubv2.Model.ImportPolicyResponse))]
    [AWSCmdletOutput("Amazon.Resiliencehubv2.Model.Policy or Amazon.Resiliencehubv2.Model.ImportPolicyResponse",
        "This cmdlet returns an Amazon.Resiliencehubv2.Model.Policy object.",
        "The service call response (type Amazon.Resiliencehubv2.Model.ImportPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportRH2PolicyCmdlet : AmazonResiliencehubv2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MultiAzDisasterRecoveryApproach
        /// <summary>
        /// <para>
        /// <para>The multi-AZ disaster recovery approach for the imported policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Resiliencehubv2.MultiAzDisasterRecoveryApproach")]
        public Amazon.Resiliencehubv2.MultiAzDisasterRecoveryApproach MultiAzDisasterRecoveryApproach { get; set; }
        #endregion
        
        #region Parameter MultiRegionDisasterRecoveryApproach
        /// <summary>
        /// <para>
        /// <para>The multi-Region disaster recovery approach for the imported policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Resiliencehubv2.MultiRegionDisasterRecoveryApproach")]
        public Amazon.Resiliencehubv2.MultiRegionDisasterRecoveryApproach MultiRegionDisasterRecoveryApproach { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
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
        
        #region Parameter AvailabilitySlo_Target
        /// <summary>
        /// <para>
        /// <para>The target availability percentage, expressed as a value between 0 and 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AvailabilitySlo_Target { get; set; }
        #endregion
        
        #region Parameter V1PolicyArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String V1PolicyArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Policy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Resiliencehubv2.Model.ImportPolicyResponse).
        /// Specifying the name of a property of type Amazon.Resiliencehubv2.Model.ImportPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Policy";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.V1PolicyArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-RH2Policy (ImportPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Resiliencehubv2.Model.ImportPolicyResponse, ImportRH2PolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilitySlo_Target = this.AvailabilitySlo_Target;
            context.ClientToken = this.ClientToken;
            context.KmsKeyId = this.KmsKeyId;
            context.MultiAzDisasterRecoveryApproach = this.MultiAzDisasterRecoveryApproach;
            context.MultiRegionDisasterRecoveryApproach = this.MultiRegionDisasterRecoveryApproach;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.V1PolicyArn = this.V1PolicyArn;
            #if MODULAR
            if (this.V1PolicyArn == null && ParameterWasBound(nameof(this.V1PolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter V1PolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.Resiliencehubv2.Model.ImportPolicyRequest();
            
            
             // populate AvailabilitySlo
            var requestAvailabilitySloIsNull = true;
            request.AvailabilitySlo = new Amazon.Resiliencehubv2.Model.AvailabilitySlo();
            System.Double? requestAvailabilitySlo_availabilitySlo_Target = null;
            if (cmdletContext.AvailabilitySlo_Target != null)
            {
                requestAvailabilitySlo_availabilitySlo_Target = cmdletContext.AvailabilitySlo_Target.Value;
            }
            if (requestAvailabilitySlo_availabilitySlo_Target != null)
            {
                request.AvailabilitySlo.Target = requestAvailabilitySlo_availabilitySlo_Target.Value;
                requestAvailabilitySloIsNull = false;
            }
             // determine if request.AvailabilitySlo should be set to null
            if (requestAvailabilitySloIsNull)
            {
                request.AvailabilitySlo = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MultiAzDisasterRecoveryApproach != null)
            {
                request.MultiAzDisasterRecoveryApproach = cmdletContext.MultiAzDisasterRecoveryApproach;
            }
            if (cmdletContext.MultiRegionDisasterRecoveryApproach != null)
            {
                request.MultiRegionDisasterRecoveryApproach = cmdletContext.MultiRegionDisasterRecoveryApproach;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.V1PolicyArn != null)
            {
                request.V1PolicyArn = cmdletContext.V1PolicyArn;
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
        
        private Amazon.Resiliencehubv2.Model.ImportPolicyResponse CallAWSServiceOperation(IAmazonResiliencehubv2 client, Amazon.Resiliencehubv2.Model.ImportPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub V2", "ImportPolicy");
            try
            {
                return client.ImportPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Double? AvailabilitySlo_Target { get; set; }
            public System.String ClientToken { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.Resiliencehubv2.MultiAzDisasterRecoveryApproach MultiAzDisasterRecoveryApproach { get; set; }
            public Amazon.Resiliencehubv2.MultiRegionDisasterRecoveryApproach MultiRegionDisasterRecoveryApproach { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String V1PolicyArn { get; set; }
            public System.Func<Amazon.Resiliencehubv2.Model.ImportPolicyResponse, ImportRH2PolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policy;
        }
        
    }
}
