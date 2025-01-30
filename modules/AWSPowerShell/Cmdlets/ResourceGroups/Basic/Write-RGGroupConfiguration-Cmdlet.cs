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
using Amazon.ResourceGroups;
using Amazon.ResourceGroups.Model;

namespace Amazon.PowerShell.Cmdlets.RG
{
    /// <summary>
    /// Attaches a service configuration to the specified group. This occurs asynchronously,
    /// and can take time to complete. You can use <a>GetGroupConfiguration</a> to check the
    /// status of the update.
    /// 
    ///  
    /// <para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para><c>resource-groups:PutGroupConfiguration</c></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "RGGroupConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Resource Groups PutGroupConfiguration API operation.", Operation = new[] {"PutGroupConfiguration"}, SelectReturnType = typeof(Amazon.ResourceGroups.Model.PutGroupConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.ResourceGroups.Model.PutGroupConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ResourceGroups.Model.PutGroupConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteRGGroupConfigurationCmdlet : AmazonResourceGroupsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>The new configuration to associate with the specified group. A configuration associates
        /// the resource group with an Amazon Web Services service and specifies how the service
        /// can interact with the resources in the group. A configuration is an array of <a>GroupConfigurationItem</a>
        /// elements.</para><para>For information about the syntax of a service configuration, see <a href="https://docs.aws.amazon.com/ARG/latest/APIReference/about-slg.html">Service
        /// configurations for Resource Groups</a>.</para><note><para>A resource group can contain either a <c>Configuration</c> or a <c>ResourceQuery</c>,
        /// but not both.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ResourceGroups.Model.GroupConfigurationItem[] Configuration { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The name or Amazon resource name (ARN) of the resource group with the configuration
        /// that you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Group { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceGroups.Model.PutGroupConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Group parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Group' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Group' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Group), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-RGGroupConfiguration (PutGroupConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceGroups.Model.PutGroupConfigurationResponse, WriteRGGroupConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Group;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Configuration != null)
            {
                context.Configuration = new List<Amazon.ResourceGroups.Model.GroupConfigurationItem>(this.Configuration);
            }
            context.Group = this.Group;
            
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
            var request = new Amazon.ResourceGroups.Model.PutGroupConfigurationRequest();
            
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            if (cmdletContext.Group != null)
            {
                request.Group = cmdletContext.Group;
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
        
        private Amazon.ResourceGroups.Model.PutGroupConfigurationResponse CallAWSServiceOperation(IAmazonResourceGroups client, Amazon.ResourceGroups.Model.PutGroupConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups", "PutGroupConfiguration");
            try
            {
                #if DESKTOP
                return client.PutGroupConfiguration(request);
                #elif CORECLR
                return client.PutGroupConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ResourceGroups.Model.GroupConfigurationItem> Configuration { get; set; }
            public System.String Group { get; set; }
            public System.Func<Amazon.ResourceGroups.Model.PutGroupConfigurationResponse, WriteRGGroupConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
