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
    /// Adds an attribute and values to, or removes an attribute and values from, a manual
    /// DB cluster snapshot.
    /// 
    ///  
    /// <para>
    /// To share a manual DB cluster snapshot with other Amazon Web Services accounts, specify
    /// <c>restore</c> as the <c>AttributeName</c> and use the <c>ValuesToAdd</c> parameter
    /// to add a list of IDs of the Amazon Web Services accounts that are authorized to restore
    /// the manual DB cluster snapshot. Use the value <c>all</c> to make the manual DB cluster
    /// snapshot public, which means that it can be copied or restored by all Amazon Web Services
    /// accounts.
    /// </para><note><para>
    /// Don't add the <c>all</c> value for any manual DB cluster snapshots that contain private
    /// information that you don't want available to all Amazon Web Services accounts.
    /// </para></note><para>
    /// If a manual DB cluster snapshot is encrypted, it can be shared, but only by specifying
    /// a list of authorized Amazon Web Services account IDs for the <c>ValuesToAdd</c> parameter.
    /// You can't use <c>all</c> as a value for that parameter in this case.
    /// </para><para>
    /// To view which Amazon Web Services accounts have access to copy or restore a manual
    /// DB cluster snapshot, or whether a manual DB cluster snapshot is public or private,
    /// use the <a>DescribeDBClusterSnapshotAttributes</a> API operation. The accounts are
    /// returned as values for the <c>restore</c> attribute.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RDSDBClusterSnapshotAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBClusterSnapshotAttributesResult")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBClusterSnapshotAttribute API operation.", Operation = new[] {"ModifyDBClusterSnapshotAttribute"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBClusterSnapshotAttributesResult or Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBClusterSnapshotAttributesResult object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSDBClusterSnapshotAttributeCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster snapshot attribute to modify.</para><para>To manage authorization for other Amazon Web Services accounts to copy or restore
        /// a manual DB cluster snapshot, set this value to <c>restore</c>.</para><note><para>To view the list of attributes available to modify, use the <a>DescribeDBClusterSnapshotAttributes</a>
        /// API operation.</para></note>
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
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter DBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the DB cluster snapshot to modify the attributes for.</para>
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
        public System.String DBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter ValuesToAdd
        /// <summary>
        /// <para>
        /// <para>A list of DB cluster snapshot attributes to add to the attribute specified by <c>AttributeName</c>.</para><para>To authorize other Amazon Web Services accounts to copy or restore a manual DB cluster
        /// snapshot, set this list to include one or more Amazon Web Services account IDs, or
        /// <c>all</c> to make the manual DB cluster snapshot restorable by any Amazon Web Services
        /// account. Do not add the <c>all</c> value for any manual DB cluster snapshots that
        /// contain private information that you don't want available to all Amazon Web Services
        /// accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ValuesToAdd { get; set; }
        #endregion
        
        #region Parameter ValuesToRemove
        /// <summary>
        /// <para>
        /// <para>A list of DB cluster snapshot attributes to remove from the attribute specified by
        /// <c>AttributeName</c>.</para><para>To remove authorization for other Amazon Web Services accounts to copy or restore
        /// a manual DB cluster snapshot, set this list to include one or more Amazon Web Services
        /// account identifiers, or <c>all</c> to remove authorization for any Amazon Web Services
        /// account to copy or restore the DB cluster snapshot. If you specify <c>all</c>, an
        /// Amazon Web Services account whose account ID is explicitly added to the <c>restore</c>
        /// attribute can still copy or restore a manual DB cluster snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ValuesToRemove { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterSnapshotAttributesResult'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterSnapshotAttributesResult";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AttributeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBClusterSnapshotAttribute (ModifyDBClusterSnapshotAttribute)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse, EditRDSDBClusterSnapshotAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttributeName = this.AttributeName;
            #if MODULAR
            if (this.AttributeName == null && ParameterWasBound(nameof(this.AttributeName)))
            {
                WriteWarning("You are passing $null as a value for parameter AttributeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBClusterSnapshotIdentifier = this.DBClusterSnapshotIdentifier;
            #if MODULAR
            if (this.DBClusterSnapshotIdentifier == null && ParameterWasBound(nameof(this.DBClusterSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ValuesToAdd != null)
            {
                context.ValuesToAdd = new List<System.String>(this.ValuesToAdd);
            }
            if (this.ValuesToRemove != null)
            {
                context.ValuesToRemove = new List<System.String>(this.ValuesToRemove);
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
            var request = new Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeRequest();
            
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeName = cmdletContext.AttributeName;
            }
            if (cmdletContext.DBClusterSnapshotIdentifier != null)
            {
                request.DBClusterSnapshotIdentifier = cmdletContext.DBClusterSnapshotIdentifier;
            }
            if (cmdletContext.ValuesToAdd != null)
            {
                request.ValuesToAdd = cmdletContext.ValuesToAdd;
            }
            if (cmdletContext.ValuesToRemove != null)
            {
                request.ValuesToRemove = cmdletContext.ValuesToRemove;
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
        
        private Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBClusterSnapshotAttribute");
            try
            {
                #if DESKTOP
                return client.ModifyDBClusterSnapshotAttribute(request);
                #elif CORECLR
                return client.ModifyDBClusterSnapshotAttributeAsync(request).GetAwaiter().GetResult();
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
            public System.String AttributeName { get; set; }
            public System.String DBClusterSnapshotIdentifier { get; set; }
            public List<System.String> ValuesToAdd { get; set; }
            public List<System.String> ValuesToRemove { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBClusterSnapshotAttributeResponse, EditRDSDBClusterSnapshotAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterSnapshotAttributesResult;
        }
        
    }
}
