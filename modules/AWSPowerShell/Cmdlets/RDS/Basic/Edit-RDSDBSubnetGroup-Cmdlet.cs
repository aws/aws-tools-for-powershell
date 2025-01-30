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
    /// Modifies an existing DB subnet group. DB subnet groups must contain at least one subnet
    /// in at least two AZs in the Amazon Web Services Region.
    /// </summary>
    [Cmdlet("Edit", "RDSDBSubnetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBSubnetGroup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBSubnetGroup API operation.", Operation = new[] {"ModifyDBSubnetGroup"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBSubnetGroupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBSubnetGroup or Amazon.RDS.Model.ModifyDBSubnetGroupResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBSubnetGroup object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBSubnetGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSDBSubnetGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBSubnetGroupDescription
        /// <summary>
        /// <para>
        /// <para>The description for the DB subnet group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupDescription { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name for the DB subnet group. This value is stored as a lowercase string. You
        /// can't modify the default subnet group.</para><para>Constraints: Must match the name of an existing DBSubnetGroup. Must not be default.</para><para>Example: <c>mydbsubnetgroup</c></para>
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
        /// <para>The EC2 subnet IDs for the DB subnet group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBSubnetGroupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBSubnetGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBSubnetGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBSubnetGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBSubnetGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBSubnetGroupName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBSubnetGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBSubnetGroup (ModifyDBSubnetGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBSubnetGroupResponse, EditRDSDBSubnetGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBSubnetGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.RDS.Model.ModifyDBSubnetGroupRequest();
            
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
        
        private Amazon.RDS.Model.ModifyDBSubnetGroupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBSubnetGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBSubnetGroup");
            try
            {
                #if DESKTOP
                return client.ModifyDBSubnetGroup(request);
                #elif CORECLR
                return client.ModifyDBSubnetGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String DBSubnetGroupDescription { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public List<System.String> SubnetId { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBSubnetGroupResponse, EditRDSDBSubnetGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBSubnetGroup;
        }
        
    }
}
