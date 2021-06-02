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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns information about a CloudFormation extension publisher.
    /// 
    ///  
    /// <para>
    /// If you do not supply a <code>PublisherId</code>, and you have registered as an extension
    /// publisher, <code>DescribePublisher</code> returns information about your own publisher
    /// account. 
    /// </para><para>
    /// For more information on registering as a publisher, see:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_RegisterPublisher.html">RegisterPublisher</a></para></li><li><para><a href="https://docs.aws.amazon.com/cloudformation-cli/latest/userguide/publish-extension.html">Publishing
    /// extensions to make them available for public use</a> in the <i>CloudFormation CLI
    /// User Guide</i></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "CFNPublisher")]
    [OutputType("Amazon.CloudFormation.Model.DescribePublisherResponse")]
    [AWSCmdlet("Calls the AWS CloudFormation DescribePublisher API operation.", Operation = new[] {"DescribePublisher"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.DescribePublisherResponse))]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.DescribePublisherResponse",
        "This cmdlet returns an Amazon.CloudFormation.Model.DescribePublisherResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFNPublisherCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter PublisherId
        /// <summary>
        /// <para>
        /// <para>The ID of the extension publisher.</para><para>If you do not supply a <code>PublisherId</code>, and you have registered as an extension
        /// publisher, <code>DescribePublisher</code> returns information about your own publisher
        /// account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PublisherId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.DescribePublisherResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.DescribePublisherResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.DescribePublisherResponse, GetCFNPublisherCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PublisherId = this.PublisherId;
            
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
            var request = new Amazon.CloudFormation.Model.DescribePublisherRequest();
            
            if (cmdletContext.PublisherId != null)
            {
                request.PublisherId = cmdletContext.PublisherId;
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
        
        private Amazon.CloudFormation.Model.DescribePublisherResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.DescribePublisherRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "DescribePublisher");
            try
            {
                #if DESKTOP
                return client.DescribePublisher(request);
                #elif CORECLR
                return client.DescribePublisherAsync(request).GetAwaiter().GetResult();
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
            public System.String PublisherId { get; set; }
            public System.Func<Amazon.CloudFormation.Model.DescribePublisherResponse, GetCFNPublisherCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
