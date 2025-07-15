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
using Amazon.Repostspace;
using Amazon.Repostspace.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RESP
{
    /// <summary>
    /// Remove a role from multiple users or groups in a private re:Post channel.
    /// </summary>
    [Cmdlet("Remove", "RESPBatchChannelRoleFromAccessor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsResponse")]
    [AWSCmdlet("Calls the AWS re:Post Private BatchRemoveChannelRoleFromAccessors API operation.", Operation = new[] {"BatchRemoveChannelRoleFromAccessors"}, SelectReturnType = typeof(Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsResponse))]
    [AWSCmdletOutput("Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsResponse",
        "This cmdlet returns an Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsResponse object containing multiple properties."
    )]
    public partial class RemoveRESPBatchChannelRoleFromAccessorCmdlet : AmazonRepostspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessorId
        /// <summary>
        /// <para>
        /// <para>The users or groups identifiers to remove the role from.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("AccessorIds")]
        public System.String[] AccessorId { get; set; }
        #endregion
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the private re:Post channel.</para>
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
        public System.String ChannelId { get; set; }
        #endregion
        
        #region Parameter ChannelRole
        /// <summary>
        /// <para>
        /// <para>The channel role to remove from the users or groups.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Repostspace.ChannelRole")]
        public Amazon.Repostspace.ChannelRole ChannelRole { get; set; }
        #endregion
        
        #region Parameter SpaceId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the private re:Post.</para>
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
        public System.String SpaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsResponse).
        /// Specifying the name of a property of type Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RESPBatchChannelRoleFromAccessor (BatchRemoveChannelRoleFromAccessors)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsResponse, RemoveRESPBatchChannelRoleFromAccessorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccessorId != null)
            {
                context.AccessorId = new List<System.String>(this.AccessorId);
            }
            #if MODULAR
            if (this.AccessorId == null && ParameterWasBound(nameof(this.AccessorId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelId = this.ChannelId;
            #if MODULAR
            if (this.ChannelId == null && ParameterWasBound(nameof(this.ChannelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelRole = this.ChannelRole;
            #if MODULAR
            if (this.ChannelRole == null && ParameterWasBound(nameof(this.ChannelRole)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SpaceId = this.SpaceId;
            #if MODULAR
            if (this.SpaceId == null && ParameterWasBound(nameof(this.SpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsRequest();
            
            if (cmdletContext.AccessorId != null)
            {
                request.AccessorIds = cmdletContext.AccessorId;
            }
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelId = cmdletContext.ChannelId;
            }
            if (cmdletContext.ChannelRole != null)
            {
                request.ChannelRole = cmdletContext.ChannelRole;
            }
            if (cmdletContext.SpaceId != null)
            {
                request.SpaceId = cmdletContext.SpaceId;
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
        
        private Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsResponse CallAWSServiceOperation(IAmazonRepostspace client, Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS re:Post Private", "BatchRemoveChannelRoleFromAccessors");
            try
            {
                return client.BatchRemoveChannelRoleFromAccessorsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AccessorId { get; set; }
            public System.String ChannelId { get; set; }
            public Amazon.Repostspace.ChannelRole ChannelRole { get; set; }
            public System.String SpaceId { get; set; }
            public System.Func<Amazon.Repostspace.Model.BatchRemoveChannelRoleFromAccessorsResponse, RemoveRESPBatchChannelRoleFromAccessorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
