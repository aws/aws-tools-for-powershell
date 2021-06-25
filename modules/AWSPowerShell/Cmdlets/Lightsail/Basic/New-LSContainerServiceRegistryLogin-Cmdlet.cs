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
using Amazon.Lightsail;
using Amazon.Lightsail.Model;

namespace Amazon.PowerShell.Cmdlets.LS
{
    /// <summary>
    /// Creates a temporary set of log in credentials that you can use to log in to the Docker
    /// process on your local machine. After you're logged in, you can use the native Docker
    /// commands to push your local container images to the container image registry of your
    /// Amazon Lightsail account so that you can use them with your Lightsail container service.
    /// The log in credentials expire 12 hours after they are created, at which point you
    /// will need to create a new set of log in credentials.
    /// 
    ///  <note><para>
    /// You can only push container images to the container service registry of your Lightsail
    /// account. You cannot pull container images or perform any other container image management
    /// actions on the container service registry.
    /// </para></note><para>
    /// After you push your container images to the container image registry of your Lightsail
    /// account, use the <code>RegisterContainerImage</code> action to register the pushed
    /// images to a specific Lightsail container service.
    /// </para><note><para>
    /// This action is not required if you install and use the Lightsail Control (lightsailctl)
    /// plugin to push container images to your Lightsail container service. For more information,
    /// see <a href="https://lightsail.aws.amazon.com/ls/docs/en_us/articles/amazon-lightsail-pushing-container-images">Pushing
    /// and managing container images on your Amazon Lightsail container services</a> in the
    /// <i>Amazon Lightsail Developer Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "LSContainerServiceRegistryLogin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lightsail.Model.ContainerServiceRegistryLogin")]
    [AWSCmdlet("Calls the Amazon Lightsail CreateContainerServiceRegistryLogin API operation.", Operation = new[] {"CreateContainerServiceRegistryLogin"}, SelectReturnType = typeof(Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginResponse))]
    [AWSCmdletOutput("Amazon.Lightsail.Model.ContainerServiceRegistryLogin or Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginResponse",
        "This cmdlet returns an Amazon.Lightsail.Model.ContainerServiceRegistryLogin object.",
        "The service call response (type Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLSContainerServiceRegistryLoginCmdlet : AmazonLightsailClientCmdlet, IExecutor
    {
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegistryLogin'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginResponse).
        /// Specifying the name of a property of type Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegistryLogin";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LSContainerServiceRegistryLogin (CreateContainerServiceRegistryLogin)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginResponse, NewLSContainerServiceRegistryLoginCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            var request = new Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginRequest();
            
            
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
        
        private Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginResponse CallAWSServiceOperation(IAmazonLightsail client, Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lightsail", "CreateContainerServiceRegistryLogin");
            try
            {
                #if DESKTOP
                return client.CreateContainerServiceRegistryLogin(request);
                #elif CORECLR
                return client.CreateContainerServiceRegistryLoginAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Lightsail.Model.CreateContainerServiceRegistryLoginResponse, NewLSContainerServiceRegistryLoginCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegistryLogin;
        }
        
    }
}
