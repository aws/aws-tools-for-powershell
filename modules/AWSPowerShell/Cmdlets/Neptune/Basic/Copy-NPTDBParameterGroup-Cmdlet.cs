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
using Amazon.Neptune;
using Amazon.Neptune.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NPT
{
    /// <summary>
    /// Copies the specified DB parameter group.
    /// </summary>
    [Cmdlet("Copy", "NPTDBParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Neptune.Model.DBParameterGroup")]
    [AWSCmdlet("Calls the Amazon Neptune CopyDBParameterGroup API operation.", Operation = new[] {"CopyDBParameterGroup"}, SelectReturnType = typeof(Amazon.Neptune.Model.CopyDBParameterGroupResponse))]
    [AWSCmdletOutput("Amazon.Neptune.Model.DBParameterGroup or Amazon.Neptune.Model.CopyDBParameterGroupResponse",
        "This cmdlet returns an Amazon.Neptune.Model.DBParameterGroup object.",
        "The service call response (type Amazon.Neptune.Model.CopyDBParameterGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyNPTDBParameterGroupCmdlet : AmazonNeptuneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SourceDBParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier or ARN for the source DB parameter group. For information about creating
        /// an ARN, see <a href="https://docs.aws.amazon.com/neptune/latest/UserGuide/tagging.ARN.html#tagging.ARN.Constructing">
        /// Constructing an Amazon Resource Name (ARN)</a>.</para><para>Constraints:</para><ul><li><para>Must specify a valid DB parameter group.</para></li><li><para>Must specify a valid DB parameter group identifier, for example <c>my-db-param-group</c>,
        /// or a valid ARN.</para></li></ul>
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
        public System.String SourceDBParameterGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the copied DB parameter group.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Neptune.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetDBParameterGroupDescription
        /// <summary>
        /// <para>
        /// <para>A description for the copied DB parameter group.</para>
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
        public System.String TargetDBParameterGroupDescription { get; set; }
        #endregion
        
        #region Parameter TargetDBParameterGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the copied DB parameter group.</para><para>Constraints:</para><ul><li><para>Cannot be null, empty, or blank.</para></li><li><para>Must contain from 1 to 255 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <c>my-db-parameter-group</c></para>
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
        public System.String TargetDBParameterGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBParameterGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Neptune.Model.CopyDBParameterGroupResponse).
        /// Specifying the name of a property of type Amazon.Neptune.Model.CopyDBParameterGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBParameterGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceDBParameterGroupIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-NPTDBParameterGroup (CopyDBParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Neptune.Model.CopyDBParameterGroupResponse, CopyNPTDBParameterGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SourceDBParameterGroupIdentifier = this.SourceDBParameterGroupIdentifier;
            #if MODULAR
            if (this.SourceDBParameterGroupIdentifier == null && ParameterWasBound(nameof(this.SourceDBParameterGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDBParameterGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Neptune.Model.Tag>(this.Tag);
            }
            context.TargetDBParameterGroupDescription = this.TargetDBParameterGroupDescription;
            #if MODULAR
            if (this.TargetDBParameterGroupDescription == null && ParameterWasBound(nameof(this.TargetDBParameterGroupDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDBParameterGroupDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetDBParameterGroupIdentifier = this.TargetDBParameterGroupIdentifier;
            #if MODULAR
            if (this.TargetDBParameterGroupIdentifier == null && ParameterWasBound(nameof(this.TargetDBParameterGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDBParameterGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Neptune.Model.CopyDBParameterGroupRequest();
            
            if (cmdletContext.SourceDBParameterGroupIdentifier != null)
            {
                request.SourceDBParameterGroupIdentifier = cmdletContext.SourceDBParameterGroupIdentifier;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetDBParameterGroupDescription != null)
            {
                request.TargetDBParameterGroupDescription = cmdletContext.TargetDBParameterGroupDescription;
            }
            if (cmdletContext.TargetDBParameterGroupIdentifier != null)
            {
                request.TargetDBParameterGroupIdentifier = cmdletContext.TargetDBParameterGroupIdentifier;
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
        
        private Amazon.Neptune.Model.CopyDBParameterGroupResponse CallAWSServiceOperation(IAmazonNeptune client, Amazon.Neptune.Model.CopyDBParameterGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune", "CopyDBParameterGroup");
            try
            {
                return client.CopyDBParameterGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SourceDBParameterGroupIdentifier { get; set; }
            public List<Amazon.Neptune.Model.Tag> Tag { get; set; }
            public System.String TargetDBParameterGroupDescription { get; set; }
            public System.String TargetDBParameterGroupIdentifier { get; set; }
            public System.Func<Amazon.Neptune.Model.CopyDBParameterGroupResponse, CopyNPTDBParameterGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBParameterGroup;
        }
        
    }
}
