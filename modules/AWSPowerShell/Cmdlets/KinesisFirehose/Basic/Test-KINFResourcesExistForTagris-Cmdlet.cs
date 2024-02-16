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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    
    /// </summary>
    [Cmdlet("Test", "KINFResourcesExistForTagris")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose VerifyResourcesExistForTagris API operation.", Operation = new[] {"VerifyResourcesExistForTagris"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisResponse))]
    [AWSCmdletOutput("System.String or Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestKINFResourcesExistForTagrisCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TagrisSweepList
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public Amazon.KinesisFirehose.Model.TagrisSweepListItem[] TagrisSweepList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TagrisSweepListResult'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisResponse).
        /// Specifying the name of a property of type Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TagrisSweepListResult";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisResponse, TestKINFResourcesExistForTagrisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.TagrisSweepList != null)
            {
                context.TagrisSweepList = new List<Amazon.KinesisFirehose.Model.TagrisSweepListItem>(this.TagrisSweepList);
            }
            #if MODULAR
            if (this.TagrisSweepList == null && ParameterWasBound(nameof(this.TagrisSweepList)))
            {
                WriteWarning("You are passing $null as a value for parameter TagrisSweepList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisRequest();
            
            if (cmdletContext.TagrisSweepList != null)
            {
                request.TagrisSweepList = cmdletContext.TagrisSweepList;
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
        
        private Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "VerifyResourcesExistForTagris");
            try
            {
                #if DESKTOP
                return client.VerifyResourcesExistForTagris(request);
                #elif CORECLR
                return client.VerifyResourcesExistForTagrisAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.KinesisFirehose.Model.TagrisSweepListItem> TagrisSweepList { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.VerifyResourcesExistForTagrisResponse, TestKINFResourcesExistForTagrisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TagrisSweepListResult;
        }
        
    }
}
