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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Authorizes the specified Amazon Web Services account to restore the specified snapshot.
    /// 
    ///  
    /// <para>
    ///  For more information about working with snapshots, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-snapshots.html">Amazon
    /// Redshift Snapshots</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Approve", "RSSnapshotAccess", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Snapshot")]
    [AWSCmdlet("Calls the Amazon Redshift AuthorizeSnapshotAccess API operation.", Operation = new[] {"AuthorizeSnapshotAccess"}, SelectReturnType = typeof(Amazon.Redshift.Model.AuthorizeSnapshotAccessResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.Snapshot or Amazon.Redshift.Model.AuthorizeSnapshotAccessResponse",
        "This cmdlet returns an Amazon.Redshift.Model.Snapshot object.",
        "The service call response (type Amazon.Redshift.Model.AuthorizeSnapshotAccessResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ApproveRSSnapshotAccessCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountWithRestoreAccess
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Web Services account authorized to restore the specified
        /// snapshot.</para><para>To share a snapshot with Amazon Web Services Support, specify amazon-redshift-support.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AccountWithRestoreAccess { get; set; }
        #endregion
        
        #region Parameter SnapshotArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the snapshot to authorize access to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotArn { get; set; }
        #endregion
        
        #region Parameter SnapshotClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster the snapshot was created from.</para><ul><li><para><i>If the snapshot to access doesn't exist and the associated IAM policy doesn't
        /// allow access to all (*) snapshots</i> - This parameter is required. Otherwise, permissions
        /// aren't available to check if the snapshot exists.</para></li><li><para><i>If the snapshot to access exists</i> - This parameter isn't required. Redshift
        /// can retrieve the cluster identifier and use it to validate snapshot authorization.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnapshotClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter SnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the snapshot the account is authorized to restore.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.AuthorizeSnapshotAccessResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.AuthorizeSnapshotAccessResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshot";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SnapshotIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SnapshotIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SnapshotIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-RSSnapshotAccess (AuthorizeSnapshotAccess)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.AuthorizeSnapshotAccessResponse, ApproveRSSnapshotAccessCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SnapshotIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountWithRestoreAccess = this.AccountWithRestoreAccess;
            #if MODULAR
            if (this.AccountWithRestoreAccess == null && ParameterWasBound(nameof(this.AccountWithRestoreAccess)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountWithRestoreAccess which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotArn = this.SnapshotArn;
            context.SnapshotClusterIdentifier = this.SnapshotClusterIdentifier;
            context.SnapshotIdentifier = this.SnapshotIdentifier;
            
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
            var request = new Amazon.Redshift.Model.AuthorizeSnapshotAccessRequest();
            
            if (cmdletContext.AccountWithRestoreAccess != null)
            {
                request.AccountWithRestoreAccess = cmdletContext.AccountWithRestoreAccess;
            }
            if (cmdletContext.SnapshotArn != null)
            {
                request.SnapshotArn = cmdletContext.SnapshotArn;
            }
            if (cmdletContext.SnapshotClusterIdentifier != null)
            {
                request.SnapshotClusterIdentifier = cmdletContext.SnapshotClusterIdentifier;
            }
            if (cmdletContext.SnapshotIdentifier != null)
            {
                request.SnapshotIdentifier = cmdletContext.SnapshotIdentifier;
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
        
        private Amazon.Redshift.Model.AuthorizeSnapshotAccessResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.AuthorizeSnapshotAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "AuthorizeSnapshotAccess");
            try
            {
                #if DESKTOP
                return client.AuthorizeSnapshotAccess(request);
                #elif CORECLR
                return client.AuthorizeSnapshotAccessAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountWithRestoreAccess { get; set; }
            public System.String SnapshotArn { get; set; }
            public System.String SnapshotClusterIdentifier { get; set; }
            public System.String SnapshotIdentifier { get; set; }
            public System.Func<Amazon.Redshift.Model.AuthorizeSnapshotAccessResponse, ApproveRSSnapshotAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshot;
        }
        
    }
}
