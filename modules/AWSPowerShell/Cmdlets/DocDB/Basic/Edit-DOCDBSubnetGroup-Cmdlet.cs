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
using System.Threading;
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Modifies an existing subnet group. subnet groups must contain at least one subnet
    /// in at least two Availability Zones in the Amazon Web Services Region.
    /// </summary>
    [Cmdlet("Edit", "DOCDBSubnetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.DBSubnetGroup")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) ModifyDBSubnetGroup API operation.", Operation = new[] {"ModifyDBSubnetGroup"}, SelectReturnType = typeof(Amazon.DocDB.Model.ModifyDBSubnetGroupResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBSubnetGroup or Amazon.DocDB.Model.ModifyDBSubnetGroupResponse",
        "This cmdlet returns an Amazon.DocDB.Model.DBSubnetGroup object.",
        "The service call response (type Amazon.DocDB.Model.ModifyDBSubnetGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditDOCDBSubnetGroupCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBSubnetGroupDescription
        /// <summary>
        /// <para>
        /// <para>The description for the subnet group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupDescription { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name for the subnet group. This value is stored as a lowercase string. You can't
        /// modify the default subnet group. </para><para>Constraints: Must match the name of an existing <c>DBSubnetGroup</c>. Must not be
        /// default.</para><para>Example: <c>mySubnetgroup</c></para>
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
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 subnet IDs for the subnet group.</para>
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
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBSubnetGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.ModifyDBSubnetGroupResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.ModifyDBSubnetGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBSubnetGroup";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBSubnetGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DOCDBSubnetGroup (ModifyDBSubnetGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.ModifyDBSubnetGroupResponse, EditDOCDBSubnetGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBSubnetGroupDescription = this.DBSubnetGroupDescription;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            #if MODULAR
            if (this.DBSubnetGroupName == null && ParameterWasBound(nameof(this.DBSubnetGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter DBSubnetGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DocDB.Model.ModifyDBSubnetGroupRequest();
            
            if (cmdletContext.DBSubnetGroupDescription != null)
            {
                request.DBSubnetGroupDescription = cmdletContext.DBSubnetGroupDescription;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
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
        
        private Amazon.DocDB.Model.ModifyDBSubnetGroupResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.ModifyDBSubnetGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "ModifyDBSubnetGroup");
            try
            {
                return client.ModifyDBSubnetGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBSubnetGroupDescription { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public List<System.String> SubnetId { get; set; }
            public System.Func<Amazon.DocDB.Model.ModifyDBSubnetGroupResponse, EditDOCDBSubnetGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBSubnetGroup;
        }
        
    }
}
