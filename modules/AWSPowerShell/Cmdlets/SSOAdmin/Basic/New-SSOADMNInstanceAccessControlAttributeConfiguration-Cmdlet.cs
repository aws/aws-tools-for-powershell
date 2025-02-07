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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Enables the attributes-based access control (ABAC) feature for the specified IAM Identity
    /// Center instance. You can also specify new attributes to add to your ABAC configuration
    /// during the enabling process. For more information about ABAC, see <a href="/singlesignon/latest/userguide/abac.html">Attribute-Based
    /// Access Control</a> in the <i>IAM Identity Center User Guide</i>.
    /// 
    ///  <note><para>
    /// After a successful response, call <c>DescribeInstanceAccessControlAttributeConfiguration</c>
    /// to validate that <c>InstanceAccessControlAttributeConfiguration</c> was created.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SSOADMNInstanceAccessControlAttributeConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin CreateInstanceAccessControlAttributeConfiguration API operation.", Operation = new[] {"CreateInstanceAccessControlAttributeConfiguration"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.CreateInstanceAccessControlAttributeConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.SSOAdmin.Model.CreateInstanceAccessControlAttributeConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSOAdmin.Model.CreateInstanceAccessControlAttributeConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewSSOADMNInstanceAccessControlAttributeConfigurationCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceAccessControlAttributeConfiguration_AccessControlAttribute
        /// <summary>
        /// <para>
        /// <para>Lists the attributes that are configured for ABAC in the specified IAM Identity Center
        /// instance.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InstanceAccessControlAttributeConfiguration_AccessControlAttributes")]
        public Amazon.SSOAdmin.Model.AccessControlAttribute[] InstanceAccessControlAttributeConfiguration_AccessControlAttribute { get; set; }
        #endregion
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM Identity Center instance under which the operation will be executed.</para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.CreateInstanceAccessControlAttributeConfigurationResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSOADMNInstanceAccessControlAttributeConfiguration (CreateInstanceAccessControlAttributeConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.CreateInstanceAccessControlAttributeConfigurationResponse, NewSSOADMNInstanceAccessControlAttributeConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.InstanceAccessControlAttributeConfiguration_AccessControlAttribute != null)
            {
                context.InstanceAccessControlAttributeConfiguration_AccessControlAttribute = new List<Amazon.SSOAdmin.Model.AccessControlAttribute>(this.InstanceAccessControlAttributeConfiguration_AccessControlAttribute);
            }
            #if MODULAR
            if (this.InstanceAccessControlAttributeConfiguration_AccessControlAttribute == null && ParameterWasBound(nameof(this.InstanceAccessControlAttributeConfiguration_AccessControlAttribute)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceAccessControlAttributeConfiguration_AccessControlAttribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.CreateInstanceAccessControlAttributeConfigurationRequest();
            
            
             // populate InstanceAccessControlAttributeConfiguration
            var requestInstanceAccessControlAttributeConfigurationIsNull = true;
            request.InstanceAccessControlAttributeConfiguration = new Amazon.SSOAdmin.Model.InstanceAccessControlAttributeConfiguration();
            List<Amazon.SSOAdmin.Model.AccessControlAttribute> requestInstanceAccessControlAttributeConfiguration_instanceAccessControlAttributeConfiguration_AccessControlAttribute = null;
            if (cmdletContext.InstanceAccessControlAttributeConfiguration_AccessControlAttribute != null)
            {
                requestInstanceAccessControlAttributeConfiguration_instanceAccessControlAttributeConfiguration_AccessControlAttribute = cmdletContext.InstanceAccessControlAttributeConfiguration_AccessControlAttribute;
            }
            if (requestInstanceAccessControlAttributeConfiguration_instanceAccessControlAttributeConfiguration_AccessControlAttribute != null)
            {
                request.InstanceAccessControlAttributeConfiguration.AccessControlAttributes = requestInstanceAccessControlAttributeConfiguration_instanceAccessControlAttributeConfiguration_AccessControlAttribute;
                requestInstanceAccessControlAttributeConfigurationIsNull = false;
            }
             // determine if request.InstanceAccessControlAttributeConfiguration should be set to null
            if (requestInstanceAccessControlAttributeConfigurationIsNull)
            {
                request.InstanceAccessControlAttributeConfiguration = null;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
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
        
        private Amazon.SSOAdmin.Model.CreateInstanceAccessControlAttributeConfigurationResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.CreateInstanceAccessControlAttributeConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "CreateInstanceAccessControlAttributeConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateInstanceAccessControlAttributeConfiguration(request);
                #elif CORECLR
                return client.CreateInstanceAccessControlAttributeConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SSOAdmin.Model.AccessControlAttribute> InstanceAccessControlAttributeConfiguration_AccessControlAttribute { get; set; }
            public System.String InstanceArn { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.CreateInstanceAccessControlAttributeConfigurationResponse, NewSSOADMNInstanceAccessControlAttributeConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
