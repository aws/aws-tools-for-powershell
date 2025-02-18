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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates the software package configuration.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdatePackageConfiguration</a>
    /// and <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_use_passrole.html">iam:PassRole</a>
    /// actions.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTPackageConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT UpdatePackageConfiguration API operation.", Operation = new[] {"UpdatePackageConfiguration"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdatePackageConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.UpdatePackageConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.UpdatePackageConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTPackageConfigurationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter VersionUpdateByJobsConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the Job is enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? VersionUpdateByJobsConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter VersionUpdateByJobsConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role that grants permission to the IoT jobs
        /// service to update the reserved named shadow when the job successfully completes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionUpdateByJobsConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdatePackageConfigurationResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTPackageConfiguration (UpdatePackageConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdatePackageConfigurationResponse, UpdateIOTPackageConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.VersionUpdateByJobsConfig_Enabled = this.VersionUpdateByJobsConfig_Enabled;
            context.VersionUpdateByJobsConfig_RoleArn = this.VersionUpdateByJobsConfig_RoleArn;
            
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
            var request = new Amazon.IoT.Model.UpdatePackageConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate VersionUpdateByJobsConfig
            var requestVersionUpdateByJobsConfigIsNull = true;
            request.VersionUpdateByJobsConfig = new Amazon.IoT.Model.VersionUpdateByJobsConfig();
            System.Boolean? requestVersionUpdateByJobsConfig_versionUpdateByJobsConfig_Enabled = null;
            if (cmdletContext.VersionUpdateByJobsConfig_Enabled != null)
            {
                requestVersionUpdateByJobsConfig_versionUpdateByJobsConfig_Enabled = cmdletContext.VersionUpdateByJobsConfig_Enabled.Value;
            }
            if (requestVersionUpdateByJobsConfig_versionUpdateByJobsConfig_Enabled != null)
            {
                request.VersionUpdateByJobsConfig.Enabled = requestVersionUpdateByJobsConfig_versionUpdateByJobsConfig_Enabled.Value;
                requestVersionUpdateByJobsConfigIsNull = false;
            }
            System.String requestVersionUpdateByJobsConfig_versionUpdateByJobsConfig_RoleArn = null;
            if (cmdletContext.VersionUpdateByJobsConfig_RoleArn != null)
            {
                requestVersionUpdateByJobsConfig_versionUpdateByJobsConfig_RoleArn = cmdletContext.VersionUpdateByJobsConfig_RoleArn;
            }
            if (requestVersionUpdateByJobsConfig_versionUpdateByJobsConfig_RoleArn != null)
            {
                request.VersionUpdateByJobsConfig.RoleArn = requestVersionUpdateByJobsConfig_versionUpdateByJobsConfig_RoleArn;
                requestVersionUpdateByJobsConfigIsNull = false;
            }
             // determine if request.VersionUpdateByJobsConfig should be set to null
            if (requestVersionUpdateByJobsConfigIsNull)
            {
                request.VersionUpdateByJobsConfig = null;
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
        
        private Amazon.IoT.Model.UpdatePackageConfigurationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdatePackageConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdatePackageConfiguration");
            try
            {
                return client.UpdatePackageConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? VersionUpdateByJobsConfig_Enabled { get; set; }
            public System.String VersionUpdateByJobsConfig_RoleArn { get; set; }
            public System.Func<Amazon.IoT.Model.UpdatePackageConfigurationResponse, UpdateIOTPackageConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
