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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Adds one or more tags to a Security Assertion Markup Language (SAML) identity provider.
    /// For more information about these providers, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_providers_saml.html">About
    /// SAML 2.0-based federation </a>. If a tag with the same key name already exists, then
    /// that tag is overwritten with the new value.
    /// 
    ///  
    /// <para>
    /// A tag consists of a key name and an associated value. By assigning tags to your resources,
    /// you can do the following:
    /// </para><ul><li><para><b>Administrative grouping and discovery</b> - Attach tags to resources to aid in
    /// organization and search. For example, you could search for all resources with the
    /// key name <i>Project</i> and the value <i>MyImportantProject</i>. Or search for all
    /// resources with the key name <i>Cost Center</i> and the value <i>41200</i>. 
    /// </para></li><li><para><b>Access control</b> - Include tags in IAM user-based and resource-based policies.
    /// You can use tags to restrict access to only a SAML identity provider that has a specified
    /// tag attached. For examples of policies that show how to use tags to control access,
    /// see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_tags.html">Control
    /// access using IAM tags</a> in the <i>IAM User Guide</i>.
    /// </para></li></ul><note><ul><li><para>
    /// If any one of the tags is invalid or if you exceed the allowed maximum number of tags,
    /// then the entire request fails and the resource is not created. For more information
    /// about tagging, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_tags.html">Tagging
    /// IAM resources</a> in the <i>IAM User Guide</i>.
    /// </para></li><li><para>
    /// Amazon Web Services always interprets the tag <c>Value</c> as a single string. If
    /// you need to store an array, you can store comma-separated values in the string. However,
    /// you must interpret the value in your code.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Add", "IAMSAMLProviderTag", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management TagSAMLProvider API operation.", Operation = new[] {"TagSAMLProvider"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.TagSAMLProviderResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityManagement.Model.TagSAMLProviderResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityManagement.Model.TagSAMLProviderResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddIAMSAMLProviderTagCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SAMLProviderArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SAML identity provider in IAM to which you want to add tags.</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of upper and lowercase alphanumeric
        /// characters with no spaces. You can also include any of the following characters: _+=,.@-</para>
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
        public System.String SAMLProviderArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of tags that you want to attach to the SAML identity provider in IAM. Each
        /// tag consists of a key name and an associated value.</para>
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
        [Alias("Tags")]
        public Amazon.IdentityManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.TagSAMLProviderResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SAMLProviderArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-IAMSAMLProviderTag (TagSAMLProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.TagSAMLProviderResponse, AddIAMSAMLProviderTagCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SAMLProviderArn = this.SAMLProviderArn;
            #if MODULAR
            if (this.SAMLProviderArn == null && ParameterWasBound(nameof(this.SAMLProviderArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SAMLProviderArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IdentityManagement.Model.Tag>(this.Tag);
            }
            #if MODULAR
            if (this.Tag == null && ParameterWasBound(nameof(this.Tag)))
            {
                WriteWarning("You are passing $null as a value for parameter Tag which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.TagSAMLProviderRequest();
            
            if (cmdletContext.SAMLProviderArn != null)
            {
                request.SAMLProviderArn = cmdletContext.SAMLProviderArn;
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
        
        private Amazon.IdentityManagement.Model.TagSAMLProviderResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.TagSAMLProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "TagSAMLProvider");
            try
            {
                #if DESKTOP
                return client.TagSAMLProvider(request);
                #elif CORECLR
                return client.TagSAMLProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String SAMLProviderArn { get; set; }
            public List<Amazon.IdentityManagement.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.TagSAMLProviderResponse, AddIAMSAMLProviderTagCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
