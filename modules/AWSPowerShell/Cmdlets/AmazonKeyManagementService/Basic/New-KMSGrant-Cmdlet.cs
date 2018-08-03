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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Adds a grant to a customer master key (CMK). The grant specifies who can use the CMK
    /// and under what conditions. When setting permissions, grants are an alternative to
    /// key policies. 
    /// 
    ///  
    /// <para>
    /// To perform this operation on a CMK in a different AWS account, specify the key ARN
    /// in the value of the <code>KeyId</code> parameter. For more information about grants,
    /// see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/grants.html">Grants</a>
    /// in the <i>AWS Key Management Service Developer Guide</i>.
    /// </para><para>
    /// The result of this operation varies with the key state of the CMK. For details, see
    /// <a href="http://docs.aws.amazon.com/kms/latest/developerguide/key-state.html">How
    /// Key State Affects Use of a Customer Master Key</a> in the <i>AWS Key Management Service
    /// Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KMSGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.CreateGrantResponse")]
    [AWSCmdlet("Calls the AWS Key Management Service CreateGrant API operation.", Operation = new[] {"CreateGrant"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.CreateGrantResponse",
        "This cmdlet returns a Amazon.KeyManagementService.Model.CreateGrantResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSGrantCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Constraints_EncryptionContextEqual
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that must be present in the encryption context of certain
        /// subsequent operations that the grant allows. When certain subsequent operations allowed
        /// by the grant include encryption context that matches this list, the grant allows the
        /// operation. Otherwise, the grant does not allow the operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Constraints_EncryptionContextEquals")]
        public System.Collections.Hashtable Constraints_EncryptionContextEqual { get; set; }
        #endregion
        
        #region Parameter Constraints_EncryptionContextSubset
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs, all of which must be present in the encryption context
        /// of certain subsequent operations that the grant allows. When certain subsequent operations
        /// allowed by the grant include encryption context that matches this list or is a superset
        /// of this list, the grant allows the operation. Otherwise, the grant does not allow
        /// the operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable Constraints_EncryptionContextSubset { get; set; }
        #endregion
        
        #region Parameter GranteePrincipal
        /// <summary>
        /// <para>
        /// <para>The principal that is given permission to perform the operations that the grant permits.</para><para>To specify the principal, use the <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of an AWS principal. Valid AWS principals include AWS accounts
        /// (root), IAM users, IAM roles, federated users, and assumed role users. For examples
        /// of the ARN syntax to use for specifying a principal, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-iam">AWS
        /// Identity and Access Management (IAM)</a> in the Example ARNs section of the <i>AWS
        /// General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GranteePrincipal { get; set; }
        #endregion
        
        #region Parameter GrantToken
        /// <summary>
        /// <para>
        /// <para>A list of grant tokens.</para><para>For more information, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#grant_token">Grant
        /// Tokens</a> in the <i>AWS Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        #endregion
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the customer master key (CMK) that the grant applies to.</para><para>Specify the key ID or the Amazon Resource Name (ARN) of the CMK. To specify a CMK
        /// in a different AWS account, you must use the key ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li></ul><para>To get the key ID and key ARN for a CMK, use <a>ListKeys</a> or <a>DescribeKey</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A friendly name for identifying the grant. Use this value to prevent the unintended
        /// creation of duplicate grants when retrying this request.</para><para>When this value is absent, all <code>CreateGrant</code> requests result in a new grant
        /// with a unique <code>GrantId</code> even if all the supplied parameters are identical.
        /// This can result in unintended duplicates when you retry the <code>CreateGrant</code>
        /// request.</para><para>When this value is present, you can retry a <code>CreateGrant</code> request with
        /// identical parameters; if the grant already exists, the original <code>GrantId</code>
        /// is returned without creating a new grant. Note that the returned grant token is unique
        /// with every <code>CreateGrant</code> request, even when a duplicate <code>GrantId</code>
        /// is returned. All grant tokens obtained in this way can be used interchangeably.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Operation
        /// <summary>
        /// <para>
        /// <para>A list of operations that the grant permits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Operations")]
        public System.String[] Operation { get; set; }
        #endregion
        
        #region Parameter RetiringPrincipal
        /// <summary>
        /// <para>
        /// <para>The principal that is given permission to retire the grant by using <a>RetireGrant</a>
        /// operation.</para><para>To specify the principal, use the <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Name (ARN)</a> of an AWS principal. Valid AWS principals include AWS accounts
        /// (root), IAM users, federated users, and assumed role users. For examples of the ARN
        /// syntax to use for specifying a principal, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html#arn-syntax-iam">AWS
        /// Identity and Access Management (IAM)</a> in the Example ARNs section of the <i>AWS
        /// General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RetiringPrincipal { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("KeyId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSGrant (CreateGrant)"))
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
            
            if (this.Constraints_EncryptionContextEqual != null)
            {
                context.Constraints_EncryptionContextEquals = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Constraints_EncryptionContextEqual.Keys)
                {
                    context.Constraints_EncryptionContextEquals.Add((String)hashKey, (String)(this.Constraints_EncryptionContextEqual[hashKey]));
                }
            }
            if (this.Constraints_EncryptionContextSubset != null)
            {
                context.Constraints_EncryptionContextSubset = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Constraints_EncryptionContextSubset.Keys)
                {
                    context.Constraints_EncryptionContextSubset.Add((String)hashKey, (String)(this.Constraints_EncryptionContextSubset[hashKey]));
                }
            }
            context.GranteePrincipal = this.GranteePrincipal;
            if (this.GrantToken != null)
            {
                context.GrantTokens = new List<System.String>(this.GrantToken);
            }
            context.KeyId = this.KeyId;
            context.Name = this.Name;
            if (this.Operation != null)
            {
                context.Operations = new List<System.String>(this.Operation);
            }
            context.RetiringPrincipal = this.RetiringPrincipal;
            
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
            var request = new Amazon.KeyManagementService.Model.CreateGrantRequest();
            
            
             // populate Constraints
            bool requestConstraintsIsNull = true;
            request.Constraints = new Amazon.KeyManagementService.Model.GrantConstraints();
            Dictionary<System.String, System.String> requestConstraints_constraints_EncryptionContextEqual = null;
            if (cmdletContext.Constraints_EncryptionContextEquals != null)
            {
                requestConstraints_constraints_EncryptionContextEqual = cmdletContext.Constraints_EncryptionContextEquals;
            }
            if (requestConstraints_constraints_EncryptionContextEqual != null)
            {
                request.Constraints.EncryptionContextEquals = requestConstraints_constraints_EncryptionContextEqual;
                requestConstraintsIsNull = false;
            }
            Dictionary<System.String, System.String> requestConstraints_constraints_EncryptionContextSubset = null;
            if (cmdletContext.Constraints_EncryptionContextSubset != null)
            {
                requestConstraints_constraints_EncryptionContextSubset = cmdletContext.Constraints_EncryptionContextSubset;
            }
            if (requestConstraints_constraints_EncryptionContextSubset != null)
            {
                request.Constraints.EncryptionContextSubset = requestConstraints_constraints_EncryptionContextSubset;
                requestConstraintsIsNull = false;
            }
             // determine if request.Constraints should be set to null
            if (requestConstraintsIsNull)
            {
                request.Constraints = null;
            }
            if (cmdletContext.GranteePrincipal != null)
            {
                request.GranteePrincipal = cmdletContext.GranteePrincipal;
            }
            if (cmdletContext.GrantTokens != null)
            {
                request.GrantTokens = cmdletContext.GrantTokens;
            }
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Operations != null)
            {
                request.Operations = cmdletContext.Operations;
            }
            if (cmdletContext.RetiringPrincipal != null)
            {
                request.RetiringPrincipal = cmdletContext.RetiringPrincipal;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.KeyManagementService.Model.CreateGrantResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.CreateGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "CreateGrant");
            try
            {
                #if DESKTOP
                return client.CreateGrant(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateGrantAsync(request);
                return task.Result;
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
            public Dictionary<System.String, System.String> Constraints_EncryptionContextEquals { get; set; }
            public Dictionary<System.String, System.String> Constraints_EncryptionContextSubset { get; set; }
            public System.String GranteePrincipal { get; set; }
            public List<System.String> GrantTokens { get; set; }
            public System.String KeyId { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Operations { get; set; }
            public System.String RetiringPrincipal { get; set; }
        }
        
    }
}
