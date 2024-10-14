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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Describes a task definition. You can specify a <c>family</c> and <c>revision</c> to
    /// find information about a specific task definition, or you can simply specify the family
    /// to find the latest <c>ACTIVE</c> revision in that family.
    /// 
    ///  <note><para>
    /// You can only describe <c>INACTIVE</c> task definitions while an active task or service
    /// references them.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "ECSTaskDefinitionDetail")]
    [OutputType("Amazon.ECS.Model.DescribeTaskDefinitionResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service DescribeTaskDefinition API operation.", Operation = new[] {"DescribeTaskDefinition"}, SelectReturnType = typeof(Amazon.ECS.Model.DescribeTaskDefinitionResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.DescribeTaskDefinitionResponse",
        "This cmdlet returns an Amazon.ECS.Model.DescribeTaskDefinitionResponse object containing multiple properties."
    )]
    public partial class GetECSTaskDefinitionDetailCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Include
        /// <summary>
        /// <para>
        /// <para>Determines whether to see the resource tags for the task definition. If <c>TAGS</c>
        /// is specified, the tags are included in the response. If this field is omitted, tags
        /// aren't included in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Include { get; set; }
        #endregion
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <c>family</c> for the latest <c>ACTIVE</c> revision, <c>family</c> and <c>revision</c>
        /// (<c>family:revision</c>) for a specific revision in the family, or full Amazon Resource
        /// Name (ARN) of the task definition to describe.</para>
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
        public System.String TaskDefinition { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.DescribeTaskDefinitionResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.DescribeTaskDefinitionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TaskDefinition parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TaskDefinition' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TaskDefinition' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.DescribeTaskDefinitionResponse, GetECSTaskDefinitionDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TaskDefinition;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Include != null)
            {
                context.Include = new List<System.String>(this.Include);
            }
            context.TaskDefinition = this.TaskDefinition;
            #if MODULAR
            if (this.TaskDefinition == null && ParameterWasBound(nameof(this.TaskDefinition)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskDefinition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ECS.Model.DescribeTaskDefinitionRequest();
            
            if (cmdletContext.Include != null)
            {
                request.Include = cmdletContext.Include;
            }
            if (cmdletContext.TaskDefinition != null)
            {
                request.TaskDefinition = cmdletContext.TaskDefinition;
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
        
        private Amazon.ECS.Model.DescribeTaskDefinitionResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.DescribeTaskDefinitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "DescribeTaskDefinition");
            try
            {
                #if DESKTOP
                return client.DescribeTaskDefinition(request);
                #elif CORECLR
                return client.DescribeTaskDefinitionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Include { get; set; }
            public System.String TaskDefinition { get; set; }
            public System.Func<Amazon.ECS.Model.DescribeTaskDefinitionResponse, GetECSTaskDefinitionDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
