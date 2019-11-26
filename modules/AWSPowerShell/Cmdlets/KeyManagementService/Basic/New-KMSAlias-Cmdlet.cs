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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Creates a display name for a customer managed customer master key (CMK). You can use
    /// an alias to identify a CMK in cryptographic operations, such as <a>Encrypt</a> and
    /// <a>GenerateDataKey</a>. You can change the CMK associated with the alias at any time.
    /// 
    ///  
    /// <para>
    /// Aliases are easier to remember than key IDs. They can also help to simplify your applications.
    /// For example, if you use an alias in your code, you can change the CMK your code uses
    /// by associating a given alias with a different CMK. 
    /// </para><para>
    /// To run the same code in multiple AWS regions, use an alias in your code, such as <code>alias/ApplicationKey</code>.
    /// Then, in each AWS Region, create an <code>alias/ApplicationKey</code> alias that is
    /// associated with a CMK in that Region. When you run your code, it uses the <code>alias/ApplicationKey</code>
    /// CMK for that AWS Region without any Region-specific code.
    /// </para><para>
    /// This operation does not return a response. To get the alias that you created, use
    /// the <a>ListAliases</a> operation.
    /// </para><para>
    /// To use aliases successfully, be aware of the following information.
    /// </para><ul><li><para>
    /// Each alias points to only one CMK at a time, although a single CMK can have multiple
    /// aliases. The alias and its associated CMK must be in the same AWS account and Region.
    /// 
    /// </para></li><li><para>
    /// You can associate an alias with any customer managed CMK in the same AWS account and
    /// Region. However, you do not have permission to associate an alias with an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-managed-cmk">AWS
    /// managed CMK</a> or an <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-owned-cmk">AWS
    /// owned CMK</a>. 
    /// </para></li><li><para>
    /// To change the CMK associated with an alias, use the <a>UpdateAlias</a> operation.
    /// The current CMK and the new CMK must be the same type (both symmetric or both asymmetric)
    /// and they must have the same key usage (<code>ENCRYPT_DECRYPT</code> or <code>SIGN_VERIFY</code>).
    /// This restriction prevents cryptographic errors in code that uses aliases.
    /// </para></li><li><para>
    /// The alias name must begin with <code>alias/</code> followed by a name, such as <code>alias/ExampleAlias</code>.
    /// It can contain only alphanumeric characters, forward slashes (/), underscores (_),
    /// and dashes (-). The alias name cannot begin with <code>alias/aws/</code>. The <code>alias/aws/</code>
    /// prefix is reserved for <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-managed-cmk">AWS
    /// managed CMKs</a>. 
    /// </para></li><li><para>
    /// The alias name must be unique within an AWS Region. However, you can use the same
    /// alias name in multiple Regions of the same AWS account. Each instance of the alias
    /// is associated with a CMK in its Region.
    /// </para></li><li><para>
    /// After you create an alias, you cannot change its alias name. However, you can use
    /// the <a>DeleteAlias</a> operation to delete the alias and then create a new alias with
    /// the desired name.
    /// </para></li><li><para>
    /// You can use an alias name or alias ARN to identify a CMK in AWS KMS cryptographic
    /// operations and in the <a>DescribeKey</a> operation. However, you cannot use alias
    /// names or alias ARNs in API operations that manage CMKs, such as <a>DisableKey</a>
    /// or <a>GetKeyPolicy</a>. For information about the valid CMK identifiers for each AWS
    /// KMS API operation, see the descriptions of the <code>KeyId</code> parameter in the
    /// API operation documentation.
    /// </para></li></ul><para>
    /// Because an alias is not a property of a CMK, you can delete and change the aliases
    /// of a CMK without affecting the CMK. Also, aliases do not appear in the response from
    /// the <a>DescribeKey</a> operation. To get the aliases and alias ARNs of CMKs in each
    /// AWS account and Region, use the <a>ListAliases</a> operation.
    /// </para><para>
    /// The CMK that you use for this operation must be in a compatible key state. For details,
    /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">How
    /// Key State Affects Use of a Customer Master Key</a> in the <i>AWS Key Management Service
    /// Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service CreateAlias API operation.", Operation = new[] {"CreateAlias"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.CreateAliasResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.CreateAliasResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.CreateAliasResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSAliasCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AliasName
        /// <summary>
        /// <para>
        /// <para>Specifies the alias name. This value must begin with <code>alias/</code> followed
        /// by a name, such as <code>alias/ExampleAlias</code>. The alias name cannot begin with
        /// <code>alias/aws/</code>. The <code>alias/aws/</code> prefix is reserved for AWS managed
        /// CMKs.</para>
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
        public System.String AliasName { get; set; }
        #endregion
        
        #region Parameter TargetKeyId
        /// <summary>
        /// <para>
        /// <para>Identifies the CMK to which the alias refers. Specify the key ID or the Amazon Resource
        /// Name (ARN) of the CMK. You cannot specify another alias. For help finding the key
        /// ID and ARN, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/viewing-keys.html#find-cmk-id-arn">Finding
        /// the Key ID and ARN</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
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
        public System.String TargetKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.CreateAliasResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetKeyId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetKeyId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetKeyId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetKeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSAlias (CreateAlias)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.CreateAliasResponse, NewKMSAliasCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetKeyId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AliasName = this.AliasName;
            #if MODULAR
            if (this.AliasName == null && ParameterWasBound(nameof(this.AliasName)))
            {
                WriteWarning("You are passing $null as a value for parameter AliasName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetKeyId = this.TargetKeyId;
            #if MODULAR
            if (this.TargetKeyId == null && ParameterWasBound(nameof(this.TargetKeyId)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetKeyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KeyManagementService.Model.CreateAliasRequest();
            
            if (cmdletContext.AliasName != null)
            {
                request.AliasName = cmdletContext.AliasName;
            }
            if (cmdletContext.TargetKeyId != null)
            {
                request.TargetKeyId = cmdletContext.TargetKeyId;
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
        
        private Amazon.KeyManagementService.Model.CreateAliasResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.CreateAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "CreateAlias");
            try
            {
                #if DESKTOP
                return client.CreateAlias(request);
                #elif CORECLR
                return client.CreateAliasAsync(request).GetAwaiter().GetResult();
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
            public System.String AliasName { get; set; }
            public System.String TargetKeyId { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.CreateAliasResponse, NewKMSAliasCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
