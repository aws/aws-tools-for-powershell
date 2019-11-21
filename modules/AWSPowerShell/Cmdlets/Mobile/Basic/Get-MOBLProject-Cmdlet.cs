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
using Amazon.Mobile;
using Amazon.Mobile.Model;

namespace Amazon.PowerShell.Cmdlets.MOBL
{
    /// <summary>
    /// Gets details about a project in AWS Mobile Hub.
    /// </summary>
    [Cmdlet("Get", "MOBLProject")]
    [OutputType("Amazon.Mobile.Model.ProjectDetails")]
    [AWSCmdlet("Calls the AWS Mobile DescribeProject API operation.", Operation = new[] {"DescribeProject"}, SelectReturnType = typeof(Amazon.Mobile.Model.DescribeProjectResponse))]
    [AWSCmdletOutput("Amazon.Mobile.Model.ProjectDetails or Amazon.Mobile.Model.DescribeProjectResponse",
        "This cmdlet returns an Amazon.Mobile.Model.ProjectDetails object.",
        "The service call response (type Amazon.Mobile.Model.DescribeProjectResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetMOBLProjectCmdlet : AmazonMobileClientCmdlet, IExecutor
    {
        
        #region Parameter ProjectId
        /// <summary>
        /// <para>
        /// <para> Unique project identifier. </para>
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
        public System.String ProjectId { get; set; }
        #endregion
        
        #region Parameter SyncFromResource
        /// <summary>
        /// <para>
        /// <para> If set to true, causes AWS Mobile Hub to synchronize information from other services,
        /// e.g., update state of AWS CloudFormation stacks in the AWS Mobile Hub project. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SyncFromResources")]
        public System.Boolean? SyncFromResource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Details'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mobile.Model.DescribeProjectResponse).
        /// Specifying the name of a property of type Amazon.Mobile.Model.DescribeProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Details";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Mobile.Model.DescribeProjectResponse, GetMOBLProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ProjectId = this.ProjectId;
            #if MODULAR
            if (this.ProjectId == null && ParameterWasBound(nameof(this.ProjectId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SyncFromResource = this.SyncFromResource;
            
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
            var request = new Amazon.Mobile.Model.DescribeProjectRequest();
            
            if (cmdletContext.ProjectId != null)
            {
                request.ProjectId = cmdletContext.ProjectId;
            }
            if (cmdletContext.SyncFromResource != null)
            {
                request.SyncFromResources = cmdletContext.SyncFromResource.Value;
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
        
        private Amazon.Mobile.Model.DescribeProjectResponse CallAWSServiceOperation(IAmazonMobile client, Amazon.Mobile.Model.DescribeProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Mobile", "DescribeProject");
            try
            {
                #if DESKTOP
                return client.DescribeProject(request);
                #elif CORECLR
                return client.DescribeProjectAsync(request).GetAwaiter().GetResult();
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
            public System.String ProjectId { get; set; }
            public System.Boolean? SyncFromResource { get; set; }
            public System.Func<Amazon.Mobile.Model.DescribeProjectResponse, GetMOBLProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Details;
        }
        
    }
}
