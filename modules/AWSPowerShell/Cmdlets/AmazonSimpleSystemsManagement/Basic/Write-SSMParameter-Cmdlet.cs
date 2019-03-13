/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Add a parameter to the system.
    /// </summary>
    [Cmdlet("Write", "SSMParameter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the AWS Systems Manager PutParameter API operation.", Operation = new[] {"PutParameter"})]
    [AWSCmdletOutput("System.Int64",
        "This cmdlet returns a Int64 object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.PutParameterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSSMParameterCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter AllowedPattern
        /// <summary>
        /// <para>
        /// <para>A regular expression used to validate the parameter value. For example, for String
        /// types with values restricted to numbers, you can specify the following: AllowedPattern=^\d+$
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AllowedPattern { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Information about the parameter that you want to add to the system. Optional but recommended.</para><important><para>Do not enter personally identifiable information in this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The KMS Key ID that you want to use to encrypt a parameter. Either the default AWS
        /// Key Management Service (AWS KMS) key automatically assigned to your AWS account or
        /// a custom key. Required for parameters that use the <code>SecureString</code> data
        /// type.</para><para>If you don't specify a key ID, the system uses the default key associated with your
        /// AWS account.</para><ul><li><para>To use your default AWS KMS key, choose the <code>SecureString</code> data type, and
        /// do <i>not</i> specify the <code>Key ID</code> when you create the parameter. The system
        /// automatically populates <code>Key ID</code> with your default KMS key.</para></li><li><para>To use a custom KMS key, choose the <code>SecureString</code> data type with the <code>Key
        /// ID</code> parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The fully qualified name of the parameter that you want to add to the system. The
        /// fully qualified name includes the complete hierarchy of the parameter path and name.
        /// For example: <code>/Dev/DBServer/MySQL/db-string13</code></para><para>Naming Constraints:</para><ul><li><para>Parameter names are case sensitive.</para></li><li><para>A parameter name must be unique within an AWS Region</para></li><li><para>A parameter name can't be prefixed with "aws" or "ssm" (case-insensitive).</para></li><li><para>Parameter names can include only the following symbols and letters: <code>a-zA-Z0-9_.-/</code></para></li><li><para>A parameter name can't include spaces.</para></li><li><para>Parameter hierarchies are limited to a maximum depth of fifteen levels.</para></li></ul><para>For additional information about valid values for parameter names, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/sysman-parameter-name-constraints.html">Requirements
        /// and Constraints for Parameter Names</a> in the <i>AWS Systems Manager User Guide</i>.</para><note><para>The maximum length constraint listed below includes capacity for additional system
        /// attributes that are not part of the name. The maximum length for the fully qualified
        /// parameter name is 1011 characters. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Overwrite
        /// <summary>
        /// <para>
        /// <para>Overwrite an existing parameter. If not specified, will default to "false".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Overwrite { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you assign to a resource. Tags enable you to categorize a resource
        /// in different ways, such as by purpose, owner, or environment. For example, you might
        /// want to tag a Systems Manager parameter to identify the type of resource to which
        /// it applies, the environment, or the type of configuration data referenced by the parameter.
        /// In this case, you could specify the following key name/value pairs:</para><ul><li><para><code>Key=Resource,Value=S3bucket</code></para></li><li><para><code>Key=OS,Value=Windows</code></para></li><li><para><code>Key=ParameterType,Value=LicenseKey</code></para></li></ul><note><para>To add tags to an existing Systems Manager parameter, use the <a>AddTagsToResource</a>
        /// action.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of parameter that you want to add to the system.</para><para>Items in a <code>StringList</code> must be separated by a comma (,). You can't use
        /// other punctuation or special character to escape items in the list. If you have a
        /// parameter value that requires a comma, then use the <code>String</code> data type.</para><note><para><code>SecureString</code> is not currently supported for AWS CloudFormation templates
        /// or in the China Regions.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.ParameterType")]
        public Amazon.SimpleSystemsManagement.ParameterType Type { get; set; }
        #endregion
        
        #region Parameter Value
        /// <summary>
        /// <para>
        /// <para>The parameter value that you want to add to the system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Value { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SSMParameter (PutParameter)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AllowedPattern = this.AllowedPattern;
            context.Description = this.Description;
            context.KeyId = this.KeyId;
            context.Name = this.Name;
            if (ParameterWasBound("Overwrite"))
                context.Overwrite = this.Overwrite;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
            }
            context.Type = this.Type;
            context.Value = this.Value;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.PutParameterRequest();
            
            if (cmdletContext.AllowedPattern != null)
            {
                request.AllowedPattern = cmdletContext.AllowedPattern;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Overwrite != null)
            {
                request.Overwrite = cmdletContext.Overwrite.Value;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            if (cmdletContext.Value != null)
            {
                request.Value = cmdletContext.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Version;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.SimpleSystemsManagement.Model.PutParameterResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.PutParameterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "PutParameter");
            try
            {
                #if DESKTOP
                return client.PutParameter(request);
                #elif CORECLR
                return client.PutParameterAsync(request).GetAwaiter().GetResult();
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
            public System.String AllowedPattern { get; set; }
            public System.String Description { get; set; }
            public System.String KeyId { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? Overwrite { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tags { get; set; }
            public Amazon.SimpleSystemsManagement.ParameterType Type { get; set; }
            public System.String Value { get; set; }
        }
        
    }
}
