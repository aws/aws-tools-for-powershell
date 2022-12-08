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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Specifies the configuration data for a registered CloudFormation extension, in the
    /// given account and region.
    /// 
    ///  
    /// <para>
    /// To view the current configuration data for an extension, refer to the <code>ConfigurationSchema</code>
    /// element of <a href="AWSCloudFormation/latest/APIReference/API_DescribeType.html">DescribeType</a>.
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/registry-register.html#registry-set-configuration">Configuring
    /// extensions at the account level</a> in the <i>CloudFormation User Guide</i>.
    /// </para><important><para>
    /// It's strongly recommended that you use dynamic references to restrict sensitive configuration
    /// definitions, such as third-party credentials. For more details on dynamic references,
    /// see <a href="https://docs.aws.amazon.com/">Using dynamic references to specify template
    /// values</a> in the <i>CloudFormation User Guide</i>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Set", "CFNTypeConfiguration")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation SetTypeConfiguration API operation.", Operation = new[] {"SetTypeConfiguration"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.SetTypeConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.SetTypeConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.SetTypeConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCFNTypeConfigurationCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>The configuration data for the extension, in this account and region.</para><para>The configuration data must be formatted as JSON, and validate against the schema
        /// returned in the <code>ConfigurationSchema</code> response element of <a href="AWSCloudFormation/latest/APIReference/API_DescribeType.html">API_DescribeType</a>.
        /// For more information, see <a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/resource-type-model.html#resource-type-howto-configuration">Defining
        /// account-level configuration data for an extension</a> in the <i>CloudFormation CLI
        /// User Guide</i>.</para>
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
        public System.String Configuration { get; set; }
        #endregion
        
        #region Parameter ConfigurationAlias
        /// <summary>
        /// <para>
        /// <para>An alias by which to refer to this extension configuration data.</para><para>Conditional: Specifying a configuration alias is required when setting a configuration
        /// for a resource type extension.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationAlias { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of extension.</para><para>Conditional: You must specify <code>ConfigurationArn</code>, or <code>Type</code>
        /// and <code>TypeName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.ThirdPartyType")]
        public Amazon.CloudFormation.ThirdPartyType Type { get; set; }
        #endregion
        
        #region Parameter TypeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the extension, in this account and region.</para><para>For public extensions, this will be the ARN assigned when you <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_ActivateType.html">activate
        /// the type</a> in this account and region. For private extensions, this will be the
        /// ARN assigned when you <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_RegisterType.html">register
        /// the type</a> in this account and region.</para><para>Do not include the extension versions suffix at the end of the ARN. You can set the
        /// configuration for an extension, but not for a specific extension version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeArn { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para>The name of the extension.</para><para>Conditional: You must specify <code>ConfigurationArn</code>, or <code>Type</code>
        /// and <code>TypeName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConfigurationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.SetTypeConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.SetTypeConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConfigurationArn";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.SetTypeConfigurationResponse, SetCFNTypeConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration = this.Configuration;
            #if MODULAR
            if (this.Configuration == null && ParameterWasBound(nameof(this.Configuration)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigurationAlias = this.ConfigurationAlias;
            context.Type = this.Type;
            context.TypeArn = this.TypeArn;
            context.TypeName = this.TypeName;
            
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
            var request = new Amazon.CloudFormation.Model.SetTypeConfigurationRequest();
            
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            if (cmdletContext.ConfigurationAlias != null)
            {
                request.ConfigurationAlias = cmdletContext.ConfigurationAlias;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.TypeArn != null)
            {
                request.TypeArn = cmdletContext.TypeArn;
            }
            if (cmdletContext.TypeName != null)
            {
                request.TypeName = cmdletContext.TypeName;
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
        
        private Amazon.CloudFormation.Model.SetTypeConfigurationResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.SetTypeConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "SetTypeConfiguration");
            try
            {
                #if DESKTOP
                return client.SetTypeConfiguration(request);
                #elif CORECLR
                return client.SetTypeConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String Configuration { get; set; }
            public System.String ConfigurationAlias { get; set; }
            public Amazon.CloudFormation.ThirdPartyType Type { get; set; }
            public System.String TypeArn { get; set; }
            public System.String TypeName { get; set; }
            public System.Func<Amazon.CloudFormation.Model.SetTypeConfigurationResponse, SetCFNTypeConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConfigurationArn;
        }
        
    }
}
