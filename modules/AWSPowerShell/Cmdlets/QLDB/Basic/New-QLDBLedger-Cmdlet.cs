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
using Amazon.QLDB;
using Amazon.QLDB.Model;

namespace Amazon.PowerShell.Cmdlets.QLDB
{
    /// <summary>
    /// Creates a new ledger in your Amazon Web Services account in the current Region.
    /// </summary>
    [Cmdlet("New", "QLDBLedger", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QLDB.Model.CreateLedgerResponse")]
    [AWSCmdlet("Calls the Amazon QLDB CreateLedger API operation.", Operation = new[] {"CreateLedger"}, SelectReturnType = typeof(Amazon.QLDB.Model.CreateLedgerResponse))]
    [AWSCmdletOutput("Amazon.QLDB.Model.CreateLedgerResponse",
        "This cmdlet returns an Amazon.QLDB.Model.CreateLedgerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQLDBLedgerCmdlet : AmazonQLDBClientCmdlet, IExecutor
    {
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>The flag that prevents a ledger from being deleted by any user. If not provided on
        /// ledger creation, this feature is enabled (<code>true</code>) by default.</para><para>If deletion protection is enabled, you must first disable it before you can delete
        /// the ledger. You can disable it by calling the <code>UpdateLedger</code> operation
        /// to set the flag to <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter KmsKey
        /// <summary>
        /// <para>
        /// <para>The key in Key Management Service (KMS) to use for encryption of data at rest in the
        /// ledger. For more information, see <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/encryption-at-rest.html">Encryption
        /// at rest</a> in the <i>Amazon QLDB Developer Guide</i>.</para><para>Use one of the following options to specify this parameter:</para><ul><li><para><code>AWS_OWNED_KMS_KEY</code>: Use an KMS key that is owned and managed by Amazon
        /// Web Services on your behalf.</para></li><li><para><b>Undefined</b>: By default, use an Amazon Web Services owned KMS key.</para></li><li><para><b>A valid symmetric customer managed KMS key</b>: Use the specified KMS key in your
        /// account that you create, own, and manage.</para><para>Amazon QLDB does not support asymmetric keys. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Using
        /// symmetric and asymmetric keys</a> in the <i>Key Management Service Developer Guide</i>.</para></li></ul><para>To specify a customer managed KMS key, you can use its key ID, Amazon Resource Name
        /// (ARN), alias name, or alias ARN. When using an alias name, prefix it with <code>"alias/"</code>.
        /// To specify a key in a different Amazon Web Services account, you must use the key
        /// ARN or alias ARN.</para><para>For example:</para><ul><li><para>Key ID: <code>1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li><li><para>Alias name: <code>alias/ExampleAlias</code></para></li><li><para>Alias ARN: <code>arn:aws:kms:us-east-2:111122223333:alias/ExampleAlias</code></para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id">Key
        /// identifiers (KeyId)</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the ledger that you want to create. The name must be unique among all
        /// of the ledgers in your Amazon Web Services account in the current Region.</para><para>Naming constraints for ledger names are defined in <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/limits.html#limits.naming">Quotas
        /// in Amazon QLDB</a> in the <i>Amazon QLDB Developer Guide</i>.</para>
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
        
        #region Parameter PermissionsMode
        /// <summary>
        /// <para>
        /// <para>The permissions mode to assign to the ledger that you want to create. This parameter
        /// can have one of the following values:</para><ul><li><para><code>ALLOW_ALL</code>: A legacy permissions mode that enables access control with
        /// API-level granularity for ledgers.</para><para>This mode allows users who have the <code>SendCommand</code> API permission for this
        /// ledger to run all PartiQL commands (hence, <code>ALLOW_ALL</code>) on any tables in
        /// the specified ledger. This mode disregards any table-level or command-level IAM permissions
        /// policies that you create for the ledger.</para></li><li><para><code>STANDARD</code>: (<i>Recommended</i>) A permissions mode that enables access
        /// control with finer granularity for ledgers, tables, and PartiQL commands.</para><para>By default, this mode denies all user requests to run any PartiQL commands on any
        /// tables in this ledger. To allow PartiQL commands to run, you must create IAM permissions
        /// policies for specific table resources and PartiQL actions, in addition to the <code>SendCommand</code>
        /// API permission for the ledger. For information, see <a href="https://docs.aws.amazon.com/qldb/latest/developerguide/getting-started-standard-mode.html">Getting
        /// started with the standard permissions mode</a> in the <i>Amazon QLDB Developer Guide</i>.</para></li></ul><note><para>We strongly recommend using the <code>STANDARD</code> permissions mode to maximize
        /// the security of your ledger data.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QLDB.PermissionsMode")]
        public Amazon.QLDB.PermissionsMode PermissionsMode { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pairs to add as tags to the ledger that you want to create. Tag keys
        /// are case sensitive. Tag values are case sensitive and can be null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QLDB.Model.CreateLedgerResponse).
        /// Specifying the name of a property of type Amazon.QLDB.Model.CreateLedgerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QLDBLedger (CreateLedger)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QLDB.Model.CreateLedgerResponse, NewQLDBLedgerCmdlet>(Select) ??
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
            context.DeletionProtection = this.DeletionProtection;
            context.KmsKey = this.KmsKey;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PermissionsMode = this.PermissionsMode;
            #if MODULAR
            if (this.PermissionsMode == null && ParameterWasBound(nameof(this.PermissionsMode)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionsMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.QLDB.Model.CreateLedgerRequest();
            
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.KmsKey != null)
            {
                request.KmsKey = cmdletContext.KmsKey;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PermissionsMode != null)
            {
                request.PermissionsMode = cmdletContext.PermissionsMode;
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
        
        private Amazon.QLDB.Model.CreateLedgerResponse CallAWSServiceOperation(IAmazonQLDB client, Amazon.QLDB.Model.CreateLedgerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QLDB", "CreateLedger");
            try
            {
                #if DESKTOP
                return client.CreateLedger(request);
                #elif CORECLR
                return client.CreateLedgerAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionProtection { get; set; }
            public System.String KmsKey { get; set; }
            public System.String Name { get; set; }
            public Amazon.QLDB.PermissionsMode PermissionsMode { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.QLDB.Model.CreateLedgerResponse, NewQLDBLedgerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
