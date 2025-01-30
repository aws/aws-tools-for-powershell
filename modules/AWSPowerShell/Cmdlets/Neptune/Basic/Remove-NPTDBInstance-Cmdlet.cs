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
using Amazon.Neptune;
using Amazon.Neptune.Model;

namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// The DeleteDBInstance action deletes a previously provisioned DB instance. When you
    /// delete a DB instance, all automated backups for that instance are deleted and can't
    /// be recovered. Manual DB snapshots of the DB instance to be deleted by <c>DeleteDBInstance</c>
    /// are not deleted.
    /// 
    ///  
    /// <para>
    ///  If you request a final DB snapshot the status of the Amazon Neptune DB instance is
    /// <c>deleting</c> until the DB snapshot is created. The API action <c>DescribeDBInstance</c>
    /// is used to monitor the status of this operation. The action can't be canceled or reverted
    /// once submitted.
    /// </para><para>
    /// Note that when a DB instance is in a failure state and has a status of <c>failed</c>,
    /// <c>incompatible-restore</c>, or <c>incompatible-network</c>, you can only delete it
    /// when the <c>SkipFinalSnapshot</c> parameter is set to <c>true</c>.
    /// </para><para>
    /// You can't delete a DB instance if it is the only instance in the DB cluster, or if
    /// it has deletion protection enabled.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "NPTDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Neptune.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Neptune DeleteDBInstance API operation.", Operation = new[] {"DeleteDBInstance"}, SelectReturnType = typeof(Amazon.Neptune.Model.DeleteDBInstanceResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.DBInstance or Amazon.Neptune.Model.DeleteDBInstanceResponse",
        "This cmdlet returns an Amazon.Neptune.Model.DBInstance object.",
        "The service call response (type Amazon.Neptune.Model.DeleteDBInstanceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveNPTDBInstanceCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB instance identifier for the DB instance to be deleted. This parameter isn't
        /// case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the name of an existing DB instance.</para></li></ul>
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
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter FinalDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para> The DBSnapshotIdentifier of the new DBSnapshot created when SkipFinalSnapshot is
        /// set to <c>false</c>.</para><note><para>Specifying this parameter and also setting the SkipFinalShapshot parameter to true
        /// results in an error.</para></note><para>Constraints:</para><ul><li><para>Must be 1 to 255 letters or numbers.</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li><li><para>Cannot be specified when deleting a Read Replica.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FinalDBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SkipFinalSnapshot
        /// <summary>
        /// <para>
        /// <para> Determines whether a final DB snapshot is created before the DB instance is deleted.
        /// If <c>true</c> is specified, no DBSnapshot is created. If <c>false</c> is specified,
        /// a DB snapshot is created before the DB instance is deleted.</para><para>Note that when a DB instance is in a failure state and has a status of 'failed', 'incompatible-restore',
        /// or 'incompatible-network', it can only be deleted when the SkipFinalSnapshot parameter
        /// is set to "true".</para><para>Specify <c>true</c> when deleting a Read Replica.</para><note><para>The FinalDBSnapshotIdentifier parameter must be specified if SkipFinalSnapshot is
        /// <c>false</c>.</para></note><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipFinalSnapshot { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.DeleteDBInstanceResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.DeleteDBInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstance";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBInstanceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBInstanceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-NPTDBInstance (DeleteDBInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.DeleteDBInstanceResponse, RemoveNPTDBInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBInstanceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FinalDBSnapshotIdentifier = this.FinalDBSnapshotIdentifier;
            context.SkipFinalSnapshot = this.SkipFinalSnapshot;
            
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
            var request = new Amazon.Neptune.Model.DeleteDBInstanceRequest();
            
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.FinalDBSnapshotIdentifier != null)
            {
                request.FinalDBSnapshotIdentifier = cmdletContext.FinalDBSnapshotIdentifier;
            }
            if (cmdletContext.SkipFinalSnapshot != null)
            {
                request.SkipFinalSnapshot = cmdletContext.SkipFinalSnapshot.Value;
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
        
        private Amazon.Neptune.Model.DeleteDBInstanceResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.DeleteDBInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "DeleteDBInstance");
            try
            {
                #if DESKTOP
                return client.DeleteDBInstance(request);
                #elif CORECLR
                return client.DeleteDBInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.String DBInstanceIdentifier { get; set; }
            public System.String FinalDBSnapshotIdentifier { get; set; }
            public System.Boolean? SkipFinalSnapshot { get; set; }
            public System.Func<Amazon.Neptune.Model.DeleteDBInstanceResponse, RemoveNPTDBInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstance;
        }
        
    }
}
