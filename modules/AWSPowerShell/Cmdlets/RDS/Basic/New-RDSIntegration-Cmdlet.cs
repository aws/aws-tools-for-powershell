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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a zero-ETL integration with Amazon Redshift.
    /// </summary>
    [Cmdlet("New", "RDSIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.CreateIntegrationResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CreateIntegration API operation.", Operation = new[] {"CreateIntegration"}, SelectReturnType = typeof(Amazon.RDS.Model.CreateIntegrationResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.CreateIntegrationResponse",
        "This cmdlet returns an Amazon.RDS.Model.CreateIntegrationResponse object containing multiple properties."
    )]
    public partial class NewRDSIntegrationCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalEncryptionContext
        /// <summary>
        /// <para>
        /// <para>An optional set of non-secret key–value pairs that contains additional contextual
        /// information about the data. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#encrypt_context">Encryption
        /// context</a> in the <i>Amazon Web Services Key Management Service Developer Guide</i>.</para><para>You can only include this parameter if you specify the <c>KMSKeyId</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AdditionalEncryptionContext { get; set; }
        #endregion
        
        #region Parameter DataFilter
        /// <summary>
        /// <para>
        /// <para>Data filtering options for the integration. For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/zero-etl.filtering.html">Data
        /// filtering for Aurora zero-ETL integrations with Amazon Redshift</a>. </para><para>Valid for: Integrations with Aurora MySQL source DB clusters only</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataFilter { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IntegrationName
        /// <summary>
        /// <para>
        /// <para>The name of the integration.</para>
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
        public System.String IntegrationName { get; set; }
        #endregion
        
        #region Parameter KMSKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Key Management System (Amazon Web Services KMS) key identifier
        /// for the key to use to encrypt the integration. If you don't specify an encryption
        /// key, RDS uses a default Amazon Web Services owned key. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKeyId { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the database to use as the source for replication.</para>
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
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Redshift data warehouse to use as the target for replication.</para>
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
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CreateIntegrationResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CreateIntegrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSIntegration (CreateIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CreateIntegrationResponse, NewRDSIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalEncryptionContext != null)
            {
                context.AdditionalEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalEncryptionContext.Keys)
                {
                    context.AdditionalEncryptionContext.Add((String)hashKey, (System.String)(this.AdditionalEncryptionContext[hashKey]));
                }
            }
            context.DataFilter = this.DataFilter;
            context.Description = this.Description;
            context.IntegrationName = this.IntegrationName;
            #if MODULAR
            if (this.IntegrationName == null && ParameterWasBound(nameof(this.IntegrationName)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KMSKeyId = this.KMSKeyId;
            context.SourceArn = this.SourceArn;
            #if MODULAR
            if (this.SourceArn == null && ParameterWasBound(nameof(this.SourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            context.TargetArn = this.TargetArn;
            #if MODULAR
            if (this.TargetArn == null && ParameterWasBound(nameof(this.TargetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.CreateIntegrationRequest();
            
            if (cmdletContext.AdditionalEncryptionContext != null)
            {
                request.AdditionalEncryptionContext = cmdletContext.AdditionalEncryptionContext;
            }
            if (cmdletContext.DataFilter != null)
            {
                request.DataFilter = cmdletContext.DataFilter;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IntegrationName != null)
            {
                request.IntegrationName = cmdletContext.IntegrationName;
            }
            if (cmdletContext.KMSKeyId != null)
            {
                request.KMSKeyId = cmdletContext.KMSKeyId;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
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
        
        private Amazon.RDS.Model.CreateIntegrationResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CreateIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CreateIntegration");
            try
            {
                #if DESKTOP
                return client.CreateIntegration(request);
                #elif CORECLR
                return client.CreateIntegrationAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AdditionalEncryptionContext { get; set; }
            public System.String DataFilter { get; set; }
            public System.String Description { get; set; }
            public System.String IntegrationName { get; set; }
            public System.String KMSKeyId { get; set; }
            public System.String SourceArn { get; set; }
            public List<Amazon.RDS.Model.Tag> Tag { get; set; }
            public System.String TargetArn { get; set; }
            public System.Func<Amazon.RDS.Model.CreateIntegrationResponse, NewRDSIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
