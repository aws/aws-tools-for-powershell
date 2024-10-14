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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Activates, deactivates Amazon Inspector deep inspection, or updates custom paths for
    /// your account.
    /// </summary>
    [Cmdlet("Update", "INS2Ec2DeepInspectionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationResponse")]
    [AWSCmdlet("Calls the Inspector2 UpdateEc2DeepInspectionConfiguration API operation.", Operation = new[] {"UpdateEc2DeepInspectionConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateINS2Ec2DeepInspectionConfigurationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActivateDeepInspection
        /// <summary>
        /// <para>
        /// <para>Specify <c>TRUE</c> to activate Amazon Inspector deep inspection in your account,
        /// or <c>FALSE</c> to deactivate. Member accounts in an organization cannot deactivate
        /// deep inspection, instead the delegated administrator for the organization can deactivate
        /// a member account using <a href="https://docs.aws.amazon.com/inspector/v2/APIReference/API_BatchUpdateMemberEc2DeepInspectionStatus.html">BatchUpdateMemberEc2DeepInspectionStatus</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.Boolean? ActivateDeepInspection { get; set; }
        #endregion
        
        #region Parameter PackagePath
        /// <summary>
        /// <para>
        /// <para>The Amazon Inspector deep inspection custom paths you are adding for your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PackagePaths")]
        public System.String[] PackagePath { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ActivateDeepInspection parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ActivateDeepInspection' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ActivateDeepInspection' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActivateDeepInspection), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INS2Ec2DeepInspectionConfiguration (UpdateEc2DeepInspectionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationResponse, UpdateINS2Ec2DeepInspectionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ActivateDeepInspection;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActivateDeepInspection = this.ActivateDeepInspection;
            if (this.PackagePath != null)
            {
                context.PackagePath = new List<System.String>(this.PackagePath);
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
            var request = new Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationRequest();
            
            if (cmdletContext.ActivateDeepInspection != null)
            {
                request.ActivateDeepInspection = cmdletContext.ActivateDeepInspection.Value;
            }
            if (cmdletContext.PackagePath != null)
            {
                request.PackagePaths = cmdletContext.PackagePath;
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
        
        private Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "UpdateEc2DeepInspectionConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateEc2DeepInspectionConfiguration(request);
                #elif CORECLR
                return client.UpdateEc2DeepInspectionConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ActivateDeepInspection { get; set; }
            public List<System.String> PackagePath { get; set; }
            public System.Func<Amazon.Inspector2.Model.UpdateEc2DeepInspectionConfigurationResponse, UpdateINS2Ec2DeepInspectionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
