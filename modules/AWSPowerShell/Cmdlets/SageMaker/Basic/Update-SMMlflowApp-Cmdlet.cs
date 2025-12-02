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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates an MLflow App.
    /// </summary>
    [Cmdlet("Update", "SMMlflowApp", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateMlflowApp API operation.", Operation = new[] {"UpdateMlflowApp"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateMlflowAppResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateMlflowAppResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateMlflowAppResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMMlflowAppCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountDefaultStatus
        /// <summary>
        /// <para>
        /// <para>Indicates whether this this MLflow App is the default for the account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AccountDefaultStatus")]
        public Amazon.SageMaker.AccountDefaultStatus AccountDefaultStatus { get; set; }
        #endregion
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the MLflow App to update.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter ArtifactStoreUri
        /// <summary>
        /// <para>
        /// <para>The new S3 URI for the general purpose bucket to use as the artifact store for the
        /// MLflow App.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArtifactStoreUri { get; set; }
        #endregion
        
        #region Parameter DefaultDomainIdList
        /// <summary>
        /// <para>
        /// <para>List of SageMaker Domain IDs for which this MLflow App is the default.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] DefaultDomainIdList { get; set; }
        #endregion
        
        #region Parameter ModelRegistrationMode
        /// <summary>
        /// <para>
        /// <para>Whether to enable or disable automatic registration of new MLflow models to the SageMaker
        /// Model Registry. To enable automatic model registration, set this value to <c>AutoModelRegistrationEnabled</c>.
        /// To disable automatic model registration, set this value to <c>AutoModelRegistrationDisabled</c>.
        /// If not specified, <c>AutomaticModelRegistration</c> defaults to <c>AutoModelRegistrationEnabled</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ModelRegistrationMode")]
        public Amazon.SageMaker.ModelRegistrationMode ModelRegistrationMode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the MLflow App to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter WeeklyMaintenanceWindowStart
        /// <summary>
        /// <para>
        /// <para>The new weekly maintenance window start day and time to update. The maintenance window
        /// day and time should be in Coordinated Universal Time (UTC) 24-hour standard time.
        /// For example: TUE:03:30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WeeklyMaintenanceWindowStart { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateMlflowAppResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateMlflowAppResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMMlflowApp (UpdateMlflowApp)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateMlflowAppResponse, UpdateSMMlflowAppCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountDefaultStatus = this.AccountDefaultStatus;
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ArtifactStoreUri = this.ArtifactStoreUri;
            if (this.DefaultDomainIdList != null)
            {
                context.DefaultDomainIdList = new List<System.String>(this.DefaultDomainIdList);
            }
            context.ModelRegistrationMode = this.ModelRegistrationMode;
            context.Name = this.Name;
            context.WeeklyMaintenanceWindowStart = this.WeeklyMaintenanceWindowStart;
            
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
            var request = new Amazon.SageMaker.Model.UpdateMlflowAppRequest();
            
            if (cmdletContext.AccountDefaultStatus != null)
            {
                request.AccountDefaultStatus = cmdletContext.AccountDefaultStatus;
            }
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.ArtifactStoreUri != null)
            {
                request.ArtifactStoreUri = cmdletContext.ArtifactStoreUri;
            }
            if (cmdletContext.DefaultDomainIdList != null)
            {
                request.DefaultDomainIdList = cmdletContext.DefaultDomainIdList;
            }
            if (cmdletContext.ModelRegistrationMode != null)
            {
                request.ModelRegistrationMode = cmdletContext.ModelRegistrationMode;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.WeeklyMaintenanceWindowStart != null)
            {
                request.WeeklyMaintenanceWindowStart = cmdletContext.WeeklyMaintenanceWindowStart;
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
        
        private Amazon.SageMaker.Model.UpdateMlflowAppResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateMlflowAppRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateMlflowApp");
            try
            {
                return client.UpdateMlflowAppAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.AccountDefaultStatus AccountDefaultStatus { get; set; }
            public System.String Arn { get; set; }
            public System.String ArtifactStoreUri { get; set; }
            public List<System.String> DefaultDomainIdList { get; set; }
            public Amazon.SageMaker.ModelRegistrationMode ModelRegistrationMode { get; set; }
            public System.String Name { get; set; }
            public System.String WeeklyMaintenanceWindowStart { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateMlflowAppResponse, UpdateSMMlflowAppCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
