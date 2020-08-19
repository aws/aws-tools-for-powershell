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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Add a parameter to the system.
    /// </summary>
    [Cmdlet("Write", "SSMParameter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the AWS Systems Manager PutParameter API operation.", Operation = new[] {"PutParameter"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.PutParameterResponse))]
    [AWSCmdletOutput("System.Int64 or Amazon.SimpleSystemsManagement.Model.PutParameterResponse",
        "This cmdlet returns a System.Int64 object.",
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AllowedPattern { get; set; }
        #endregion
        
        #region Parameter DataType
        /// <summary>
        /// <para>
        /// <para>The data type for a <code>String</code> parameter. Supported data types include plain
        /// text and Amazon Machine Image IDs.</para><para><b>The following data type values are supported.</b></para><ul><li><para><code>text</code></para></li><li><para><code>aws:ec2:image</code></para></li></ul><para>When you create a <code>String</code> parameter and specify <code>aws:ec2:image</code>,
        /// Systems Manager validates the parameter value is in the required format, such as <code>ami-12345abcdeEXAMPLE</code>,
        /// and that the specified AMI is available in your AWS account. For more information,
        /// see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/parameter-store-ec2-aliases.html">Native
        /// parameter support for Amazon Machine Image IDs</a> in the <i>AWS Systems Manager User
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Information about the parameter that you want to add to the system. Optional but recommended.</para><important><para>Do not enter personally identifiable information in this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// For parameters in a hierarchy, you must include a leading forward slash character
        /// (/) when you create or reference a parameter. For example: <code>/Dev/DBServer/MySQL/db-string13</code></para><para>Naming Constraints:</para><ul><li><para>Parameter names are case sensitive.</para></li><li><para>A parameter name must be unique within an AWS Region</para></li><li><para>A parameter name can't be prefixed with "aws" or "ssm" (case-insensitive).</para></li><li><para>Parameter names can include only the following symbols and letters: <code>a-zA-Z0-9_.-/</code></para></li><li><para>A parameter name can't include spaces.</para></li><li><para>Parameter hierarchies are limited to a maximum depth of fifteen levels.</para></li></ul><para>For additional information about valid values for parameter names, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/sysman-parameter-name-constraints.html">About
        /// requirements and constraints for parameter names</a> in the <i>AWS Systems Manager
        /// User Guide</i>.</para><note><para>The maximum length constraint listed below includes capacity for additional system
        /// attributes that are not part of the name. The maximum length for a parameter name,
        /// including the full length of the parameter ARN, is 1011 characters. For example, the
        /// length of the following parameter name is 65 characters, not 20 characters:</para><para><code>arn:aws:ssm:us-east-2:111122223333:parameter/ExampleParameterName</code></para></note>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Overwrite
        /// <summary>
        /// <para>
        /// <para>Overwrite an existing parameter. If not specified, will default to "false".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Overwrite { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>One or more policies to apply to a parameter. This action takes a JSON array. Parameter
        /// Store supports the following policy types:</para><para>Expiration: This policy deletes the parameter after it expires. When you create the
        /// policy, you specify the expiration date. You can update the expiration date and time
        /// by updating the policy. Updating the <i>parameter</i> does not affect the expiration
        /// date and time. When the expiration time is reached, Parameter Store deletes the parameter.</para><para>ExpirationNotification: This policy triggers an event in Amazon CloudWatch Events
        /// that notifies you about the expiration. By using this policy, you can receive notification
        /// before or after the expiration time is reached, in units of days or hours.</para><para>NoChangeNotification: This policy triggers a CloudWatch event if a parameter has not
        /// been modified for a specified period of time. This policy type is useful when, for
        /// example, a secret needs to be changed within a period of time, but it has not been
        /// changed.</para><para>All existing policies are preserved until you send new policies or an empty policy.
        /// For more information about parameter policies, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/parameter-store-policies.html">Assigning
        /// parameter policies</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies")]
        public System.String Policy { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// <para>The parameter tier to assign to a parameter.</para><para>Parameter Store offers a standard tier and an advanced tier for parameters. Standard
        /// parameters have a content size limit of 4 KB and can't be configured to use parameter
        /// policies. You can create a maximum of 10,000 standard parameters for each Region in
        /// an AWS account. Standard parameters are offered at no additional cost. </para><para>Advanced parameters have a content size limit of 8 KB and can be configured to use
        /// parameter policies. You can create a maximum of 100,000 advanced parameters for each
        /// Region in an AWS account. Advanced parameters incur a charge. For more information,
        /// see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/parameter-store-advanced-parameters.html">Standard
        /// and advanced parameter tiers</a> in the <i>AWS Systems Manager User Guide</i>.</para><para>You can change a standard parameter to an advanced parameter any time. But you can't
        /// revert an advanced parameter to a standard parameter. Reverting an advanced parameter
        /// to a standard parameter would result in data loss because the system would truncate
        /// the size of the parameter from 8 KB to 4 KB. Reverting would also remove any policies
        /// attached to the parameter. Lastly, advanced parameters use a different form of encryption
        /// than standard parameters. </para><para>If you no longer need an advanced parameter, or if you no longer want to incur charges
        /// for an advanced parameter, you must delete it and recreate it as a new standard parameter.
        /// </para><para><b>Using the Default Tier Configuration</b></para><para>In <code>PutParameter</code> requests, you can specify the tier to create the parameter
        /// in. Whenever you specify a tier in the request, Parameter Store creates or updates
        /// the parameter according to that request. However, if you do not specify a tier in
        /// a request, Parameter Store assigns the tier based on the current Parameter Store default
        /// tier configuration.</para><para>The default tier when you begin using Parameter Store is the standard-parameter tier.
        /// If you use the advanced-parameter tier, you can specify one of the following as the
        /// default:</para><ul><li><para><b>Advanced</b>: With this option, Parameter Store evaluates all requests as advanced
        /// parameters. </para></li><li><para><b>Intelligent-Tiering</b>: With this option, Parameter Store evaluates each request
        /// to determine if the parameter is standard or advanced. </para><para>If the request doesn't include any options that require an advanced parameter, the
        /// parameter is created in the standard-parameter tier. If one or more options requiring
        /// an advanced parameter are included in the request, Parameter Store create a parameter
        /// in the advanced-parameter tier.</para><para>This approach helps control your parameter-related costs by always creating standard
        /// parameters unless an advanced parameter is necessary. </para></li></ul><para>Options that require an advanced parameter include the following:</para><ul><li><para>The content size of the parameter is more than 4 KB.</para></li><li><para>The parameter uses a parameter policy.</para></li><li><para>More than 10,000 parameters already exist in your AWS account in the current Region.</para></li></ul><para>For more information about configuring the default tier option, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/ps-default-tier.html">Specifying
        /// a default parameter tier</a> in the <i>AWS Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.ParameterTier")]
        public Amazon.SimpleSystemsManagement.ParameterTier Tier { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of parameter that you want to add to the system.</para><note><para><code>SecureString</code> is not currently supported for AWS CloudFormation templates
        /// or in the China Regions.</para></note><para>Items in a <code>StringList</code> must be separated by a comma (,). You can't use
        /// other punctuation or special character to escape items in the list. If you have a
        /// parameter value that requires a comma, then use the <code>String</code> data type.</para><important><para>Specifying a parameter type is not required when updating a parameter. You must specify
        /// a parameter type when creating a parameter.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.ParameterType")]
        public Amazon.SimpleSystemsManagement.ParameterType Type { get; set; }
        #endregion
        
        #region Parameter Value
        /// <summary>
        /// <para>
        /// <para>The parameter value that you want to add to the system. Standard parameters have a
        /// value limit of 4 KB. Advanced parameters have a value limit of 8 KB.</para><note><para>Parameters can't be referenced or nested in the values of other parameters. You can't
        /// include <code>{{}}</code> or <code>{{ssm:<i>parameter-name</i>}}</code> in a parameter
        /// value.</para></note>
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
        public System.String Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Version'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.PutParameterResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.PutParameterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Version";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SSMParameter (PutParameter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.PutParameterResponse, WriteSSMParameterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowedPattern = this.AllowedPattern;
            context.DataType = this.DataType;
            context.Description = this.Description;
            context.KeyId = this.KeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Overwrite = this.Overwrite;
            context.Policy = this.Policy;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
            }
            context.Tier = this.Tier;
            context.Type = this.Type;
            context.Value = this.Value;
            #if MODULAR
            if (this.Value == null && ParameterWasBound(nameof(this.Value)))
            {
                WriteWarning("You are passing $null as a value for parameter Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.PutParameterRequest();
            
            if (cmdletContext.AllowedPattern != null)
            {
                request.AllowedPattern = cmdletContext.AllowedPattern;
            }
            if (cmdletContext.DataType != null)
            {
                request.DataType = cmdletContext.DataType;
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
            if (cmdletContext.Policy != null)
            {
                request.Policies = cmdletContext.Policy;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Tier != null)
            {
                request.Tier = cmdletContext.Tier;
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
            public System.String DataType { get; set; }
            public System.String Description { get; set; }
            public System.String KeyId { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? Overwrite { get; set; }
            public System.String Policy { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tag { get; set; }
            public Amazon.SimpleSystemsManagement.ParameterTier Tier { get; set; }
            public Amazon.SimpleSystemsManagement.ParameterType Type { get; set; }
            public System.String Value { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.PutParameterResponse, WriteSSMParameterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Version;
        }
        
    }
}
