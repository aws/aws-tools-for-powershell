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
    /// Creates a resilience policy that defines availability and disaster recovery requirements.
    /// </summary>
    [Cmdlet("New", "RH2Policy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Resiliencehubv2.Model.Policy")]
    [AWSCmdlet("Calls the AWS Resilience Hub V2 CreatePolicy API operation.", Operation = new[] {"CreatePolicy"}, SelectReturnType = typeof(Amazon.Resiliencehubv2.Model.CreatePolicyResponse))]
    [AWSCmdletOutput("Amazon.Resiliencehubv2.Model.Policy or Amazon.Resiliencehubv2.Model.CreatePolicyResponse",
        "This cmdlet returns an Amazon.Resiliencehubv2.Model.Policy object.",
        "The service call response (type Amazon.Resiliencehubv2.Model.CreatePolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewRH2PolicyCmdlet : AmazonResiliencehubv2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MultiAz_DisasterRecoveryApproach
        /// <summary>
        /// <para>
        /// <para>The disaster recovery approach for multi-AZ.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Resiliencehubv2.MultiAzDisasterRecoveryApproach")]
        public Amazon.Resiliencehubv2.MultiAzDisasterRecoveryApproach MultiAz_DisasterRecoveryApproach { get; set; }
        #endregion
        
        #region Parameter MultiRegion_DisasterRecoveryApproach
        /// <summary>
        /// <para>
        /// <para>The disaster recovery approach for multi-Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Resiliencehubv2.MultiRegionDisasterRecoveryApproach")]
        public Amazon.Resiliencehubv2.MultiRegionDisasterRecoveryApproach MultiRegion_DisasterRecoveryApproach { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter MultiAz_RpoInMinute
        /// <summary>
        /// <para>
        /// <para>The recovery point objective (RPO) target for multi-AZ, in minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiAz_RpoInMinutes")]
        public System.Int32? MultiAz_RpoInMinute { get; set; }
        #endregion
        
        #region Parameter MultiRegion_RpoInMinute
        /// <summary>
        /// <para>
        /// <para>The recovery point objective (RPO) target for multi-Region, in minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiRegion_RpoInMinutes")]
        public System.Int32? MultiRegion_RpoInMinute { get; set; }
        #endregion
        
        #region Parameter MultiAz_RtoInMinute
        /// <summary>
        /// <para>
        /// <para>The recovery time objective (RTO) target for multi-AZ, in minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiAz_RtoInMinutes")]
        public System.Int32? MultiAz_RtoInMinute { get; set; }
        #endregion
        
        #region Parameter MultiRegion_RtoInMinute
        /// <summary>
        /// <para>
        /// <para>The recovery time objective (RTO) target for multi-Region, in minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MultiRegion_RtoInMinutes")]
        public System.Int32? MultiRegion_RtoInMinute { get; set; }
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
        
        #region Parameter DataRecovery_TimeBetweenBackupsInMinute
        /// <summary>
        /// <para>
        /// <para>The target time between backups, in minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataRecovery_TimeBetweenBackupsInMinutes")]
        public System.Int32? DataRecovery_TimeBetweenBackupsInMinute { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Resiliencehubv2.Model.CreatePolicyResponse).
        /// Specifying the name of a property of type Amazon.Resiliencehubv2.Model.CreatePolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RH2Policy (CreatePolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Resiliencehubv2.Model.CreatePolicyResponse, NewRH2PolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilitySlo_Target = this.AvailabilitySlo_Target;
            context.ClientToken = this.ClientToken;
            context.DataRecovery_TimeBetweenBackupsInMinute = this.DataRecovery_TimeBetweenBackupsInMinute;
            context.Description = this.Description;
            context.KmsKeyId = this.KmsKeyId;
            context.MultiAz_DisasterRecoveryApproach = this.MultiAz_DisasterRecoveryApproach;
            context.MultiAz_RpoInMinute = this.MultiAz_RpoInMinute;
            context.MultiAz_RtoInMinute = this.MultiAz_RtoInMinute;
            context.MultiRegion_DisasterRecoveryApproach = this.MultiRegion_DisasterRecoveryApproach;
            context.MultiRegion_RpoInMinute = this.MultiRegion_RpoInMinute;
            context.MultiRegion_RtoInMinute = this.MultiRegion_RtoInMinute;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Resiliencehubv2.Model.CreatePolicyRequest();
            
            
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
            
             // populate DataRecovery
            var requestDataRecoveryIsNull = true;
            request.DataRecovery = new Amazon.Resiliencehubv2.Model.DataRecoveryTargets();
            System.Int32? requestDataRecovery_dataRecovery_TimeBetweenBackupsInMinute = null;
            if (cmdletContext.DataRecovery_TimeBetweenBackupsInMinute != null)
            {
                requestDataRecovery_dataRecovery_TimeBetweenBackupsInMinute = cmdletContext.DataRecovery_TimeBetweenBackupsInMinute.Value;
            }
            if (requestDataRecovery_dataRecovery_TimeBetweenBackupsInMinute != null)
            {
                request.DataRecovery.TimeBetweenBackupsInMinutes = requestDataRecovery_dataRecovery_TimeBetweenBackupsInMinute.Value;
                requestDataRecoveryIsNull = false;
            }
             // determine if request.DataRecovery should be set to null
            if (requestDataRecoveryIsNull)
            {
                request.DataRecovery = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate MultiAz
            var requestMultiAzIsNull = true;
            request.MultiAz = new Amazon.Resiliencehubv2.Model.MultiAzTargets();
            Amazon.Resiliencehubv2.MultiAzDisasterRecoveryApproach requestMultiAz_multiAz_DisasterRecoveryApproach = null;
            if (cmdletContext.MultiAz_DisasterRecoveryApproach != null)
            {
                requestMultiAz_multiAz_DisasterRecoveryApproach = cmdletContext.MultiAz_DisasterRecoveryApproach;
            }
            if (requestMultiAz_multiAz_DisasterRecoveryApproach != null)
            {
                request.MultiAz.DisasterRecoveryApproach = requestMultiAz_multiAz_DisasterRecoveryApproach;
                requestMultiAzIsNull = false;
            }
            System.Int32? requestMultiAz_multiAz_RpoInMinute = null;
            if (cmdletContext.MultiAz_RpoInMinute != null)
            {
                requestMultiAz_multiAz_RpoInMinute = cmdletContext.MultiAz_RpoInMinute.Value;
            }
            if (requestMultiAz_multiAz_RpoInMinute != null)
            {
                request.MultiAz.RpoInMinutes = requestMultiAz_multiAz_RpoInMinute.Value;
                requestMultiAzIsNull = false;
            }
            System.Int32? requestMultiAz_multiAz_RtoInMinute = null;
            if (cmdletContext.MultiAz_RtoInMinute != null)
            {
                requestMultiAz_multiAz_RtoInMinute = cmdletContext.MultiAz_RtoInMinute.Value;
            }
            if (requestMultiAz_multiAz_RtoInMinute != null)
            {
                request.MultiAz.RtoInMinutes = requestMultiAz_multiAz_RtoInMinute.Value;
                requestMultiAzIsNull = false;
            }
             // determine if request.MultiAz should be set to null
            if (requestMultiAzIsNull)
            {
                request.MultiAz = null;
            }
            
             // populate MultiRegion
            var requestMultiRegionIsNull = true;
            request.MultiRegion = new Amazon.Resiliencehubv2.Model.MultiRegionTargets();
            Amazon.Resiliencehubv2.MultiRegionDisasterRecoveryApproach requestMultiRegion_multiRegion_DisasterRecoveryApproach = null;
            if (cmdletContext.MultiRegion_DisasterRecoveryApproach != null)
            {
                requestMultiRegion_multiRegion_DisasterRecoveryApproach = cmdletContext.MultiRegion_DisasterRecoveryApproach;
            }
            if (requestMultiRegion_multiRegion_DisasterRecoveryApproach != null)
            {
                request.MultiRegion.DisasterRecoveryApproach = requestMultiRegion_multiRegion_DisasterRecoveryApproach;
                requestMultiRegionIsNull = false;
            }
            System.Int32? requestMultiRegion_multiRegion_RpoInMinute = null;
            if (cmdletContext.MultiRegion_RpoInMinute != null)
            {
                requestMultiRegion_multiRegion_RpoInMinute = cmdletContext.MultiRegion_RpoInMinute.Value;
            }
            if (requestMultiRegion_multiRegion_RpoInMinute != null)
            {
                request.MultiRegion.RpoInMinutes = requestMultiRegion_multiRegion_RpoInMinute.Value;
                requestMultiRegionIsNull = false;
            }
            System.Int32? requestMultiRegion_multiRegion_RtoInMinute = null;
            if (cmdletContext.MultiRegion_RtoInMinute != null)
            {
                requestMultiRegion_multiRegion_RtoInMinute = cmdletContext.MultiRegion_RtoInMinute.Value;
            }
            if (requestMultiRegion_multiRegion_RtoInMinute != null)
            {
                request.MultiRegion.RtoInMinutes = requestMultiRegion_multiRegion_RtoInMinute.Value;
                requestMultiRegionIsNull = false;
            }
             // determine if request.MultiRegion should be set to null
            if (requestMultiRegionIsNull)
            {
                request.MultiRegion = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Resiliencehubv2.Model.CreatePolicyResponse CallAWSServiceOperation(IAmazonResiliencehubv2 client, Amazon.Resiliencehubv2.Model.CreatePolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub V2", "CreatePolicy");
            try
            {
                return client.CreatePolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? DataRecovery_TimeBetweenBackupsInMinute { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKeyId { get; set; }
            public Amazon.Resiliencehubv2.MultiAzDisasterRecoveryApproach MultiAz_DisasterRecoveryApproach { get; set; }
            public System.Int32? MultiAz_RpoInMinute { get; set; }
            public System.Int32? MultiAz_RtoInMinute { get; set; }
            public Amazon.Resiliencehubv2.MultiRegionDisasterRecoveryApproach MultiRegion_DisasterRecoveryApproach { get; set; }
            public System.Int32? MultiRegion_RpoInMinute { get; set; }
            public System.Int32? MultiRegion_RtoInMinute { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Resiliencehubv2.Model.CreatePolicyResponse, NewRH2PolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Policy;
        }
        
    }
}
