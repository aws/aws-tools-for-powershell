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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Copies the specified cluster parameter group.
    /// </summary>
    [Cmdlet("Copy", "DOCDBClusterParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.DBClusterParameterGroup")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) CopyDBClusterParameterGroup API operation.", Operation = new[] {"CopyDBClusterParameterGroup"}, SelectReturnType = typeof(Amazon.DocDB.Model.CopyDBClusterParameterGroupResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBClusterParameterGroup or Amazon.DocDB.Model.CopyDBClusterParameterGroupResponse",
        "This cmdlet returns an Amazon.DocDB.Model.DBClusterParameterGroup object.",
        "The service call response (type Amazon.DocDB.Model.CopyDBClusterParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyDOCDBClusterParameterGroupCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SourceDBClusterParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier or Amazon Resource Name (ARN) for the source cluster parameter group.</para><para>Constraints:</para><ul><li><para>Must specify a valid cluster parameter group.</para></li><li><para>If the source cluster parameter group is in the same Amazon Web Services Region as
        /// the copy, specify a valid parameter group identifier; for example, <c>my-db-cluster-param-group</c>,
        /// or a valid ARN.</para></li><li><para>If the source parameter group is in a different Amazon Web Services Region than the
        /// copy, specify a valid cluster parameter group ARN; for example, <c>arn:aws:rds:us-east-1:123456789012:sample-cluster:sample-parameter-group</c>.</para></li></ul>
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
        public System.String SourceDBClusterParameterGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that are to be assigned to the parameter group.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DocDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBClusterParameterGroupDescription
        /// <summary>
        /// <para>
        /// <para>A description for the copied cluster parameter group.</para>
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
        public System.String TargetDBClusterParameterGroupDescription { get; set; }
        #endregion
        
        #region Parameter TargetDBClusterParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the copied cluster parameter group.</para><para>Constraints:</para><ul><li><para>Cannot be null, empty, or blank.</para></li><li><para>Must contain from 1 to 255 letters, numbers, or hyphens. </para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens. </para></li></ul><para>Example: <c>my-cluster-param-group1</c></para>
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
        public System.String TargetDBClusterParameterGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBClusterParameterGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.CopyDBClusterParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.CopyDBClusterParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBClusterParameterGroup";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetDBClusterParameterGroupIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-DOCDBClusterParameterGroup (CopyDBClusterParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.CopyDBClusterParameterGroupResponse, CopyDOCDBClusterParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SourceDBClusterParameterGroupIdentifier = this.SourceDBClusterParameterGroupIdentifier;
            #if MODULAR
            if (this.SourceDBClusterParameterGroupIdentifier == null && ParameterWasBound(nameof(this.SourceDBClusterParameterGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDBClusterParameterGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DocDB.Model.Tag>(this.Tag);
            }
            context.TargetDBClusterParameterGroupDescription = this.TargetDBClusterParameterGroupDescription;
            #if MODULAR
            if (this.TargetDBClusterParameterGroupDescription == null && ParameterWasBound(nameof(this.TargetDBClusterParameterGroupDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDBClusterParameterGroupDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetDBClusterParameterGroupIdentifier = this.TargetDBClusterParameterGroupIdentifier;
            #if MODULAR
            if (this.TargetDBClusterParameterGroupIdentifier == null && ParameterWasBound(nameof(this.TargetDBClusterParameterGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDBClusterParameterGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DocDB.Model.CopyDBClusterParameterGroupRequest();
            
            if (cmdletContext.SourceDBClusterParameterGroupIdentifier != null)
            {
                request.SourceDBClusterParameterGroupIdentifier = cmdletContext.SourceDBClusterParameterGroupIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetDBClusterParameterGroupDescription != null)
            {
                request.TargetDBClusterParameterGroupDescription = cmdletContext.TargetDBClusterParameterGroupDescription;
            }
            if (cmdletContext.TargetDBClusterParameterGroupIdentifier != null)
            {
                request.TargetDBClusterParameterGroupIdentifier = cmdletContext.TargetDBClusterParameterGroupIdentifier;
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
        
        private Amazon.DocDB.Model.CopyDBClusterParameterGroupResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.CopyDBClusterParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "CopyDBClusterParameterGroup");
            try
            {
                return client.CopyDBClusterParameterGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SourceDBClusterParameterGroupIdentifier { get; set; }
            public List<Amazon.DocDB.Model.Tag> Tag { get; set; }
            public System.String TargetDBClusterParameterGroupDescription { get; set; }
            public System.String TargetDBClusterParameterGroupIdentifier { get; set; }
            public System.Func<Amazon.DocDB.Model.CopyDBClusterParameterGroupResponse, CopyDOCDBClusterParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBClusterParameterGroup;
        }
        
    }
}
