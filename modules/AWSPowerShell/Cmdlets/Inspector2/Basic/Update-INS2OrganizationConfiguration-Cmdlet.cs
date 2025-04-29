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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Updates the configurations for your Amazon Inspector organization.
    /// </summary>
    [Cmdlet("Update", "INS2OrganizationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Inspector2.Model.AutoEnable")]
    [AWSCmdlet("Calls the Inspector2 UpdateOrganizationConfiguration API operation.", Operation = new[] {"UpdateOrganizationConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.UpdateOrganizationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.AutoEnable or Amazon.Inspector2.Model.UpdateOrganizationConfigurationResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.AutoEnable object.",
        "The service call response (type Amazon.Inspector2.Model.UpdateOrganizationConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateINS2OrganizationConfigurationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoEnable_Ec2
        /// <summary>
        /// <para>
        /// <para>Represents whether Amazon EC2 scans are automatically enabled for new members of your
        /// Amazon Inspector organization.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? AutoEnable_Ec2 { get; set; }
        #endregion
        
        #region Parameter AutoEnable_Ecr
        /// <summary>
        /// <para>
        /// <para>Represents whether Amazon ECR scans are automatically enabled for new members of your
        /// Amazon Inspector organization.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? AutoEnable_Ecr { get; set; }
        #endregion
        
        #region Parameter AutoEnable_Lambda
        /// <summary>
        /// <para>
        /// <para>Represents whether Amazon Web Services Lambda standard scans are automatically enabled
        /// for new members of your Amazon Inspector organization. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoEnable_Lambda { get; set; }
        #endregion
        
        #region Parameter AutoEnable_LambdaCode
        /// <summary>
        /// <para>
        /// Amazon.Inspector2.Model.AutoEnable.LambdaCode
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoEnable_LambdaCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutoEnable'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.UpdateOrganizationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.UpdateOrganizationConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutoEnable";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INS2OrganizationConfiguration (UpdateOrganizationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.UpdateOrganizationConfigurationResponse, UpdateINS2OrganizationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoEnable_Ec2 = this.AutoEnable_Ec2;
            #if MODULAR
            if (this.AutoEnable_Ec2 == null && ParameterWasBound(nameof(this.AutoEnable_Ec2)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoEnable_Ec2 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoEnable_Ecr = this.AutoEnable_Ecr;
            #if MODULAR
            if (this.AutoEnable_Ecr == null && ParameterWasBound(nameof(this.AutoEnable_Ecr)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoEnable_Ecr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoEnable_Lambda = this.AutoEnable_Lambda;
            context.AutoEnable_LambdaCode = this.AutoEnable_LambdaCode;
            
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
            var request = new Amazon.Inspector2.Model.UpdateOrganizationConfigurationRequest();
            
            
             // populate AutoEnable
            var requestAutoEnableIsNull = true;
            request.AutoEnable = new Amazon.Inspector2.Model.AutoEnable();
            System.Boolean? requestAutoEnable_autoEnable_Ec2 = null;
            if (cmdletContext.AutoEnable_Ec2 != null)
            {
                requestAutoEnable_autoEnable_Ec2 = cmdletContext.AutoEnable_Ec2.Value;
            }
            if (requestAutoEnable_autoEnable_Ec2 != null)
            {
                request.AutoEnable.Ec2 = requestAutoEnable_autoEnable_Ec2.Value;
                requestAutoEnableIsNull = false;
            }
            System.Boolean? requestAutoEnable_autoEnable_Ecr = null;
            if (cmdletContext.AutoEnable_Ecr != null)
            {
                requestAutoEnable_autoEnable_Ecr = cmdletContext.AutoEnable_Ecr.Value;
            }
            if (requestAutoEnable_autoEnable_Ecr != null)
            {
                request.AutoEnable.Ecr = requestAutoEnable_autoEnable_Ecr.Value;
                requestAutoEnableIsNull = false;
            }
            System.Boolean? requestAutoEnable_autoEnable_Lambda = null;
            if (cmdletContext.AutoEnable_Lambda != null)
            {
                requestAutoEnable_autoEnable_Lambda = cmdletContext.AutoEnable_Lambda.Value;
            }
            if (requestAutoEnable_autoEnable_Lambda != null)
            {
                request.AutoEnable.Lambda = requestAutoEnable_autoEnable_Lambda.Value;
                requestAutoEnableIsNull = false;
            }
            System.Boolean? requestAutoEnable_autoEnable_LambdaCode = null;
            if (cmdletContext.AutoEnable_LambdaCode != null)
            {
                requestAutoEnable_autoEnable_LambdaCode = cmdletContext.AutoEnable_LambdaCode.Value;
            }
            if (requestAutoEnable_autoEnable_LambdaCode != null)
            {
                request.AutoEnable.LambdaCode = requestAutoEnable_autoEnable_LambdaCode.Value;
                requestAutoEnableIsNull = false;
            }
             // determine if request.AutoEnable should be set to null
            if (requestAutoEnableIsNull)
            {
                request.AutoEnable = null;
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
        
        private Amazon.Inspector2.Model.UpdateOrganizationConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.UpdateOrganizationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "UpdateOrganizationConfiguration");
            try
            {
                return client.UpdateOrganizationConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AutoEnable_Ec2 { get; set; }
            public System.Boolean? AutoEnable_Ecr { get; set; }
            public System.Boolean? AutoEnable_Lambda { get; set; }
            public System.Boolean? AutoEnable_LambdaCode { get; set; }
            public System.Func<Amazon.Inspector2.Model.UpdateOrganizationConfigurationResponse, UpdateINS2OrganizationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutoEnable;
        }
        
    }
}
