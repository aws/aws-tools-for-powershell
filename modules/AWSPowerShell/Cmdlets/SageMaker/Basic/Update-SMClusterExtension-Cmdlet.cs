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
    /// Updates the configuration or the version of an extension installed on a SageMaker
    /// HyperPod cluster. SageMaker HyperPod applies the change to every node in the cluster.
    /// You can change the configuration, the version, or both in one request.
    /// 
    ///  <ul><li><para><b>Configuration:</b> You can change settings by sending <c>ConfigurationValues</c>.
    /// Settings that you include are changed. Settings that you omit keep their current values.
    /// A setting with the value <c>null</c> is removed and returns to its default value.
    /// </para></li><li><para><b>Version:</b> You can update to a later version. You can't update to an earlier
    /// version. To use an earlier version, delete the extension and create it again with
    /// that version.
    /// </para></li></ul><para>
    /// You can't update an extension while it is being deleted.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SMClusterExtension", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateClusterExtension API operation.", Operation = new[] {"UpdateClusterExtension"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateClusterExtensionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateClusterExtensionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateClusterExtensionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMClusterExtensionCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the SageMaker HyperPod cluster on which the extension
        /// is installed.</para>
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
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter ConfigurationValue
        /// <summary>
        /// <para>
        /// <para>The configuration changes to apply, as a JSON object serialized as a string. Settings
        /// that you include are changed, settings that you omit are unchanged, and a setting
        /// with the value <c>null</c> returns to its default value. The resulting configuration
        /// must be valid for the target extension version. If you omit <c>ConfigurationValues</c>,
        /// the configuration is unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationValues")]
        public System.String ConfigurationValue { get; set; }
        #endregion
        
        #region Parameter ExtensionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the extension to update.</para>
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
        public System.String ExtensionArn { get; set; }
        #endregion
        
        #region Parameter ExtensionVersion
        /// <summary>
        /// <para>
        /// <para>The version to update the extension to, in <c>MAJOR.MINOR.PATCH</c> format. The version
        /// must be later than the extension's current version. If you omit this parameter, the
        /// extension keeps its current version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExtensionVersion { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide so that the request is idempotent.
        /// If you send the same update more than once, SageMaker HyperPod applies it once and
        /// doesn't return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExtensionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateClusterExtensionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateClusterExtensionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExtensionArn";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ClusterArn),
                nameof(this.ExtensionArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMClusterExtension (UpdateClusterExtension)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateClusterExtensionResponse, UpdateSMClusterExtensionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigurationValue = this.ConfigurationValue;
            context.ExtensionArn = this.ExtensionArn;
            #if MODULAR
            if (this.ExtensionArn == null && ParameterWasBound(nameof(this.ExtensionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExtensionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExtensionVersion = this.ExtensionVersion;
            
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
            var request = new Amazon.SageMaker.Model.UpdateClusterExtensionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            if (cmdletContext.ConfigurationValue != null)
            {
                request.ConfigurationValues = cmdletContext.ConfigurationValue;
            }
            if (cmdletContext.ExtensionArn != null)
            {
                request.ExtensionArn = cmdletContext.ExtensionArn;
            }
            if (cmdletContext.ExtensionVersion != null)
            {
                request.ExtensionVersion = cmdletContext.ExtensionVersion;
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
        
        private Amazon.SageMaker.Model.UpdateClusterExtensionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateClusterExtensionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateClusterExtension");
            try
            {
                return client.UpdateClusterExtensionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public System.String ConfigurationValue { get; set; }
            public System.String ExtensionArn { get; set; }
            public System.String ExtensionVersion { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateClusterExtensionResponse, UpdateSMClusterExtensionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExtensionArn;
        }
        
    }
}
