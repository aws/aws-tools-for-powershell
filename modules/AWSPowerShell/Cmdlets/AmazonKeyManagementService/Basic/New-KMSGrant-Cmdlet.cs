/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Adds a grant to a key to specify who can access the key and under what conditions.
    /// Grants are alternate permission mechanisms to key policies. If absent, access to the
    /// key is evaluated based on IAM policies attached to the user. By default, grants do
    /// not expire. Grants can be listed, retired, or revoked as indicated by the following
    /// APIs. Typically, when you are finished using a grant, you retire it. When you want
    /// to end a grant immediately, revoke it. For more information about grants, see <a href="http://docs.aws.amazon.com/kms/latest/developerguide/grants.html">Grants</a>.
    /// <ol><li><a>ListGrants</a></li><li><a>RetireGrant</a></li><li><a>RevokeGrant</a></li></ol>
    /// </summary>
    [Cmdlet("New", "KMSGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KeyManagementService.Model.CreateGrantResult")]
    [AWSCmdlet("Invokes the CreateGrant operation against AWS Key Management Service.", Operation = new[] {"CreateGrant"})]
    [AWSCmdletOutput("Amazon.KeyManagementService.Model.CreateGrantResult",
        "This cmdlet returns a CreateGrantResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewKMSGrantCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// The constraint contains additional
        /// key/value pairs that serve to further limit the grant.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Constraints_EncryptionContextEquals")]
        public System.Collections.Hashtable Constraints_EncryptionContextEqual { get; set; }
        
        /// <summary>
        /// <para>
        /// The constraint equals the full
        /// encryption context.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable Constraints_EncryptionContextSubset { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Principal given permission by the grant to use the key identified by the <code>keyId</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String GranteePrincipal { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>List of grant tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GrantTokens")]
        public System.String[] GrantToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A unique key identifier for a customer master key. This value can be a globally unique
        /// identifier, an ARN, or an alias. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String KeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>List of operations permitted by the grant. This can be any combination of one or more
        /// of the following values: <ol><li>Decrypt</li><li>Encrypt</li><li>GenerateDataKey</li><li>GenerateDataKeyWithoutPlaintext</li><li>ReEncryptFrom</li><li>ReEncryptTo</li><li>CreateGrant</li></ol></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Operations")]
        public System.String[] Operation { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Principal given permission to retire the grant. For more information, see <a>RetireGrant</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RetiringPrincipal { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            if (this.Constraints_EncryptionContextEqual != null)
            {
                context.Constraints_EncryptionContextEquals = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Constraints_EncryptionContextEqual.Keys)
                {
                    context.Constraints_EncryptionContextEquals.Add((String)hashKey, (String)(this.Constraints_EncryptionContextEqual[hashKey]));
                }
            }
            if (this.Constraints_EncryptionContextSubset != null)
            {
                context.Constraints_EncryptionContextSubset = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Constraints_EncryptionContextSubset.Keys)
                {
                    context.Constraints_EncryptionContextSubset.Add((String)hashKey, (String)(this.Constraints_EncryptionContextSubset[hashKey]));
                }
            }
            context.GranteePrincipal = this.GranteePrincipal;
            if (this.GrantToken != null)
            {
                context.GrantTokens = new List<String>(this.GrantToken);
            }
            context.KeyId = this.KeyId;
            if (this.Operation != null)
            {
                context.Operations = new List<String>(this.Operation);
            }
            context.RetiringPrincipal = this.RetiringPrincipal;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateGrantRequest();
            
            
             // populate Constraints
            bool requestConstraintsIsNull = true;
            request.Constraints = new GrantConstraints();
            Dictionary<String, String> requestConstraints_constraints_EncryptionContextEqual = null;
            if (cmdletContext.Constraints_EncryptionContextEquals != null)
            {
                requestConstraints_constraints_EncryptionContextEqual = cmdletContext.Constraints_EncryptionContextEquals;
            }
            if (requestConstraints_constraints_EncryptionContextEqual != null)
            {
                request.Constraints.EncryptionContextEquals = requestConstraints_constraints_EncryptionContextEqual;
                requestConstraintsIsNull = false;
            }
            Dictionary<String, String> requestConstraints_constraints_EncryptionContextSubset = null;
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
                var response = client.CreateGrant(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<String, String> Constraints_EncryptionContextEquals { get; set; }
            public Dictionary<String, String> Constraints_EncryptionContextSubset { get; set; }
            public String GranteePrincipal { get; set; }
            public List<String> GrantTokens { get; set; }
            public String KeyId { get; set; }
            public List<String> Operations { get; set; }
            public String RetiringPrincipal { get; set; }
        }
        
    }
}
