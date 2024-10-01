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
using Amazon.ResourceGroups;
using Amazon.ResourceGroups.Model;

namespace Amazon.PowerShell.Cmdlets.RG
{
    /// <summary>
    /// Updates the resource query of a group. For more information about resource queries,
    /// see <a href="https://docs.aws.amazon.com/ARG/latest/userguide/gettingstarted-query.html#gettingstarted-query-cli-tag">Create
    /// a tag-based group in Resource Groups</a>.
    /// 
    ///  
    /// <para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para><c>resource-groups:UpdateGroupQuery</c></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "RGGroupQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ResourceGroups.Model.GroupQuery")]
    [AWSCmdlet("Calls the AWS Resource Groups UpdateGroupQuery API operation.", Operation = new[] {"UpdateGroupQuery"}, SelectReturnType = typeof(Amazon.ResourceGroups.Model.UpdateGroupQueryResponse))]
    [AWSCmdletOutput("Amazon.ResourceGroups.Model.GroupQuery or Amazon.ResourceGroups.Model.UpdateGroupQueryResponse",
        "This cmdlet returns an Amazon.ResourceGroups.Model.GroupQuery object.",
        "The service call response (type Amazon.ResourceGroups.Model.UpdateGroupQueryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateRGGroupQueryCmdlet : AmazonResourceGroupsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// <para>The name or the Amazon resource name (ARN) of the resource group to query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Group { get; set; }
        #endregion
        
        #region Parameter ResourceQuery
        /// <summary>
        /// <para>
        /// <para>The resource query to determine which Amazon Web Services resources are members of
        /// this resource group.</para><note><para>A resource group can contain either a <c>Configuration</c> or a <c>ResourceQuery</c>,
        /// but not both.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.ResourceGroups.Model.ResourceQuery ResourceQuery { get; set; }
        #endregion
        
        #region Parameter GroupName
        /// <summary>
        /// <para>
        /// <para>Don't use this parameter. Use <c>Group</c> instead.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This field is deprecated, use Group instead.")]
        [Alias("Name")]
        public System.String GroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GroupQuery'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResourceGroups.Model.UpdateGroupQueryResponse).
        /// Specifying the name of a property of type Amazon.ResourceGroups.Model.UpdateGroupQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GroupQuery";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceQuery parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceQuery' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceQuery' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RGGroupQuery (UpdateGroupQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ResourceGroups.Model.UpdateGroupQueryResponse, UpdateRGGroupQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceQuery;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Group = this.Group;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GroupName = this.GroupName;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ResourceQuery = this.ResourceQuery;
            #if MODULAR
            if (this.ResourceQuery == null && ParameterWasBound(nameof(this.ResourceQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ResourceGroups.Model.UpdateGroupQueryRequest();
            
            if (cmdletContext.Group != null)
            {
                request.Group = cmdletContext.Group;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.GroupName != null)
            {
                request.GroupName = cmdletContext.GroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ResourceQuery != null)
            {
                request.ResourceQuery = cmdletContext.ResourceQuery;
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
        
        private Amazon.ResourceGroups.Model.UpdateGroupQueryResponse CallAWSServiceOperation(IAmazonResourceGroups client, Amazon.ResourceGroups.Model.UpdateGroupQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resource Groups", "UpdateGroupQuery");
            try
            {
                #if DESKTOP
                return client.UpdateGroupQuery(request);
                #elif CORECLR
                return client.UpdateGroupQueryAsync(request).GetAwaiter().GetResult();
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
            public System.String Group { get; set; }
            [System.ObsoleteAttribute]
            public System.String GroupName { get; set; }
            public Amazon.ResourceGroups.Model.ResourceQuery ResourceQuery { get; set; }
            public System.Func<Amazon.ResourceGroups.Model.UpdateGroupQueryResponse, UpdateRGGroupQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GroupQuery;
        }
        
    }
}
