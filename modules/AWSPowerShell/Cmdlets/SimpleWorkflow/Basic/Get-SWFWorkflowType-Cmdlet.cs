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
using Amazon.SimpleWorkflow;
using Amazon.SimpleWorkflow.Model;

namespace Amazon.PowerShell.Cmdlets.SWF
{
    /// <summary>
    /// Returns information about the specified <i>workflow type</i>. This includes configuration
    /// settings specified when the type was registered and other information such as creation
    /// date, current status, etc.
    /// 
    ///  
    /// <para><b>Access Control</b></para><para>
    /// You can use IAM policies to control this action's access to Amazon SWF resources as
    /// follows:
    /// </para><ul><li><para>
    /// Use a <code>Resource</code> element with the domain name to limit the action to only
    /// specified domains.
    /// </para></li><li><para>
    /// Use an <code>Action</code> element to allow or deny permission to call this action.
    /// </para></li><li><para>
    /// Constrain the following parameters by using a <code>Condition</code> element with
    /// the appropriate keys.
    /// </para><ul><li><para><code>workflowType.name</code>: String constraint. The key is <code>swf:workflowType.name</code>.
    /// </para></li><li><para><code>workflowType.version</code>: String constraint. The key is <code>swf:workflowType.version</code>.
    /// </para></li></ul></li></ul><para>
    /// If the caller doesn't have sufficient permissions to invoke the action, or the parameter
    /// values fall outside the specified constraints, the action fails. The associated event
    /// attribute's <code>cause</code> parameter is set to <code>OPERATION_NOT_PERMITTED</code>.
    /// For details and example IAM policies, see <a href="https://docs.aws.amazon.com/amazonswf/latest/developerguide/swf-dev-iam.html">Using
    /// IAM to Manage Access to Amazon SWF Workflows</a> in the <i>Amazon SWF Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SWFWorkflowType")]
    [OutputType("Amazon.SimpleWorkflow.Model.WorkflowTypeDetail")]
    [AWSCmdlet("Calls the AWS Simple Workflow Service (SWF) DescribeWorkflowType API operation.", Operation = new[] {"DescribeWorkflowType"}, SelectReturnType = typeof(Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeResponse))]
    [AWSCmdletOutput("Amazon.SimpleWorkflow.Model.WorkflowTypeDetail or Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeResponse",
        "This cmdlet returns an Amazon.SimpleWorkflow.Model.WorkflowTypeDetail object.",
        "The service call response (type Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSWFWorkflowTypeCmdlet : AmazonSimpleWorkflowClientCmdlet, IExecutor
    {
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The name of the domain in which this workflow type is registered.</para>
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
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter WorkflowType_Name
        /// <summary>
        /// <para>
        /// <para> The name of the workflow type.</para><note><para>The combination of workflow type name and version must be unique with in a domain.</para></note>
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
        public System.String WorkflowType_Name { get; set; }
        #endregion
        
        #region Parameter WorkflowType_Version
        /// <summary>
        /// <para>
        /// <para> The version of the workflow type.</para><note><para>The combination of workflow type name and version must be unique with in a domain.</para></note>
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
        public System.String WorkflowType_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkflowTypeDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeResponse).
        /// Specifying the name of a property of type Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkflowTypeDetail";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkflowType_Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkflowType_Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkflowType_Name' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeResponse, GetSWFWorkflowTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkflowType_Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Domain = this.Domain;
            #if MODULAR
            if (this.Domain == null && ParameterWasBound(nameof(this.Domain)))
            {
                WriteWarning("You are passing $null as a value for parameter Domain which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowType_Name = this.WorkflowType_Name;
            #if MODULAR
            if (this.WorkflowType_Name == null && ParameterWasBound(nameof(this.WorkflowType_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowType_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowType_Version = this.WorkflowType_Version;
            #if MODULAR
            if (this.WorkflowType_Version == null && ParameterWasBound(nameof(this.WorkflowType_Version)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowType_Version which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate WorkflowType
            var requestWorkflowTypeIsNull = true;
            request.WorkflowType = new Amazon.SimpleWorkflow.Model.WorkflowType();
            System.String requestWorkflowType_workflowType_Name = null;
            if (cmdletContext.WorkflowType_Name != null)
            {
                requestWorkflowType_workflowType_Name = cmdletContext.WorkflowType_Name;
            }
            if (requestWorkflowType_workflowType_Name != null)
            {
                request.WorkflowType.Name = requestWorkflowType_workflowType_Name;
                requestWorkflowTypeIsNull = false;
            }
            System.String requestWorkflowType_workflowType_Version = null;
            if (cmdletContext.WorkflowType_Version != null)
            {
                requestWorkflowType_workflowType_Version = cmdletContext.WorkflowType_Version;
            }
            if (requestWorkflowType_workflowType_Version != null)
            {
                request.WorkflowType.Version = requestWorkflowType_workflowType_Version;
                requestWorkflowTypeIsNull = false;
            }
             // determine if request.WorkflowType should be set to null
            if (requestWorkflowTypeIsNull)
            {
                request.WorkflowType = null;
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
        
        private Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeResponse CallAWSServiceOperation(IAmazonSimpleWorkflow client, Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Simple Workflow Service (SWF)", "DescribeWorkflowType");
            try
            {
                #if DESKTOP
                return client.DescribeWorkflowType(request);
                #elif CORECLR
                return client.DescribeWorkflowTypeAsync(request).GetAwaiter().GetResult();
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
            public System.String Domain { get; set; }
            public System.String WorkflowType_Name { get; set; }
            public System.String WorkflowType_Version { get; set; }
            public System.Func<Amazon.SimpleWorkflow.Model.DescribeWorkflowTypeResponse, GetSWFWorkflowTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkflowTypeDetail;
        }
        
    }
}
