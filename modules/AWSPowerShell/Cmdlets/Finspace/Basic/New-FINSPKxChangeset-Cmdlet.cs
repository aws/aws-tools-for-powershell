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
using Amazon.Finspace;
using Amazon.Finspace.Model;

namespace Amazon.PowerShell.Cmdlets.FINSP
{
    /// <summary>
    /// Creates a changeset for a kdb database. A changeset allows you to add and delete
    /// existing files by using an ordered list of change requests.
    /// </summary>
    [Cmdlet("New", "FINSPKxChangeset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Finspace.Model.CreateKxChangesetResponse")]
    [AWSCmdlet("Calls the FinSpace User Environment Management Service CreateKxChangeset API operation.", Operation = new[] {"CreateKxChangeset"}, SelectReturnType = typeof(Amazon.Finspace.Model.CreateKxChangesetResponse))]
    [AWSCmdletOutput("Amazon.Finspace.Model.CreateKxChangesetResponse",
        "This cmdlet returns an Amazon.Finspace.Model.CreateKxChangesetResponse object containing multiple properties."
    )]
    public partial class NewFINSPKxChangesetCmdlet : AmazonFinspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChangeRequest
        /// <summary>
        /// <para>
        /// <para>A list of change request objects that are run in order. A change request object consists
        /// of <c>changeType</c> , <c>s3Path</c>, and <c>dbPath</c>. A changeType can have the
        /// following values: </para><ul><li><para>PUT – Adds or updates files in a database.</para></li><li><para>DELETE – Deletes files in a database.</para></li></ul><para>All the change requests require a mandatory <c>dbPath</c> attribute that defines the
        /// path within the database directory. All database paths must start with a leading /
        /// and end with a trailing /. The <c>s3Path</c> attribute defines the s3 source file
        /// path and is required for a PUT change type. The <c>s3path</c> must end with a trailing
        /// / if it is a directory and must end without a trailing / if it is a file. </para><para>Here are few examples of how you can use the change request object:</para><ol><li><para>This request adds a single sym file at database root location. </para><para><c>{ "changeType": "PUT", "s3Path":"s3://bucket/db/sym", "dbPath":"/"}</c></para></li><li><para>This request adds files in the given <c>s3Path</c> under the 2020.01.02 partition
        /// of the database.</para><para><c>{ "changeType": "PUT", "s3Path":"s3://bucket/db/2020.01.02/", "dbPath":"/2020.01.02/"}</c></para></li><li><para>This request adds files in the given <c>s3Path</c> under the <i>taq</i> table partition
        /// of the database.</para><para><c>[ { "changeType": "PUT", "s3Path":"s3://bucket/db/2020.01.02/taq/", "dbPath":"/2020.01.02/taq/"}]</c></para></li><li><para>This request deletes the 2020.01.02 partition of the database.</para><para><c>[{ "changeType": "DELETE", "dbPath": "/2020.01.02/"} ]</c></para></li><li><para>The <i>DELETE</i> request allows you to delete the existing files under the 2020.01.02
        /// partition of the database, and the <i>PUT</i> request adds a new taq table under it.</para><para><c>[ {"changeType": "DELETE", "dbPath":"/2020.01.02/"}, {"changeType": "PUT", "s3Path":"s3://bucket/db/2020.01.02/taq/",
        /// "dbPath":"/2020.01.02/taq/"}]</c></para></li></ol>
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
        [Alias("ChangeRequests")]
        public Amazon.Finspace.Model.ChangeRequest[] ChangeRequest { get; set; }
        #endregion
        
        #region Parameter DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the kdb database.</para>
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
        public System.String DatabaseName { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique identifier of the kdb environment.</para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Finspace.Model.CreateKxChangesetResponse).
        /// Specifying the name of a property of type Amazon.Finspace.Model.CreateKxChangesetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatabaseName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatabaseName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatabaseName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatabaseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FINSPKxChangeset (CreateKxChangeset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Finspace.Model.CreateKxChangesetResponse, NewFINSPKxChangesetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatabaseName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ChangeRequest != null)
            {
                context.ChangeRequest = new List<Amazon.Finspace.Model.ChangeRequest>(this.ChangeRequest);
            }
            #if MODULAR
            if (this.ChangeRequest == null && ParameterWasBound(nameof(this.ChangeRequest)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeRequest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DatabaseName = this.DatabaseName;
            #if MODULAR
            if (this.DatabaseName == null && ParameterWasBound(nameof(this.DatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Finspace.Model.CreateKxChangesetRequest();
            
            if (cmdletContext.ChangeRequest != null)
            {
                request.ChangeRequests = cmdletContext.ChangeRequest;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
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
        
        private Amazon.Finspace.Model.CreateKxChangesetResponse CallAWSServiceOperation(IAmazonFinspace client, Amazon.Finspace.Model.CreateKxChangesetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace User Environment Management Service", "CreateKxChangeset");
            try
            {
                #if DESKTOP
                return client.CreateKxChangeset(request);
                #elif CORECLR
                return client.CreateKxChangesetAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Finspace.Model.ChangeRequest> ChangeRequest { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.Func<Amazon.Finspace.Model.CreateKxChangesetResponse, NewFINSPKxChangesetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
