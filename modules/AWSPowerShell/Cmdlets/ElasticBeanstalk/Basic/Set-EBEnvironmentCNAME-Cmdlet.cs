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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Swaps the CNAMEs of two environments.
    /// </summary>
    [Cmdlet("Set", "EBEnvironmentCNAME", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk SwapEnvironmentCNAMEs API operation.", Operation = new[] {"SwapEnvironmentCNAMEs"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse), LegacyAlias="Set-EBEnvironmentCNAMEs")]
    [AWSCmdletOutput("None or Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetEBEnvironmentCNAMECmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter DestinationEnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the destination environment.</para><para> Condition: You must specify at least the <code>DestinationEnvironmentID</code> or
        /// the <code>DestinationEnvironmentName</code>. You may also specify both. You must specify
        /// the <code>SourceEnvironmentId</code> with the <code>DestinationEnvironmentId</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String DestinationEnvironmentId { get; set; }
        #endregion
        
        #region Parameter DestinationEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the destination environment.</para><para> Condition: You must specify at least the <code>DestinationEnvironmentID</code> or
        /// the <code>DestinationEnvironmentName</code>. You may also specify both. You must specify
        /// the <code>SourceEnvironmentName</code> with the <code>DestinationEnvironmentName</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.String DestinationEnvironmentName { get; set; }
        #endregion
        
        #region Parameter SourceEnvironmentId
        /// <summary>
        /// <para>
        /// <para>The ID of the source environment.</para><para> Condition: You must specify at least the <code>SourceEnvironmentID</code> or the
        /// <code>SourceEnvironmentName</code>. You may also specify both. If you specify the
        /// <code>SourceEnvironmentId</code>, you must specify the <code>DestinationEnvironmentId</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SourceEnvironmentId { get; set; }
        #endregion
        
        #region Parameter SourceEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the source environment.</para><para> Condition: You must specify at least the <code>SourceEnvironmentID</code> or the
        /// <code>SourceEnvironmentName</code>. You may also specify both. If you specify the
        /// <code>SourceEnvironmentName</code>, you must specify the <code>DestinationEnvironmentName</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String SourceEnvironmentName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceEnvironmentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceEnvironmentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceEnvironmentId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceEnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EBEnvironmentCNAME (SwapEnvironmentCNAMEs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse, SetEBEnvironmentCNAMECmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceEnvironmentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DestinationEnvironmentId = this.DestinationEnvironmentId;
            context.DestinationEnvironmentName = this.DestinationEnvironmentName;
            context.SourceEnvironmentId = this.SourceEnvironmentId;
            context.SourceEnvironmentName = this.SourceEnvironmentName;
            
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
            var request = new Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsRequest();
            
            if (cmdletContext.DestinationEnvironmentId != null)
            {
                request.DestinationEnvironmentId = cmdletContext.DestinationEnvironmentId;
            }
            if (cmdletContext.DestinationEnvironmentName != null)
            {
                request.DestinationEnvironmentName = cmdletContext.DestinationEnvironmentName;
            }
            if (cmdletContext.SourceEnvironmentId != null)
            {
                request.SourceEnvironmentId = cmdletContext.SourceEnvironmentId;
            }
            if (cmdletContext.SourceEnvironmentName != null)
            {
                request.SourceEnvironmentName = cmdletContext.SourceEnvironmentName;
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
        
        private Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "SwapEnvironmentCNAMEs");
            try
            {
                #if DESKTOP
                return client.SwapEnvironmentCNAMEs(request);
                #elif CORECLR
                return client.SwapEnvironmentCNAMEsAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationEnvironmentId { get; set; }
            public System.String DestinationEnvironmentName { get; set; }
            public System.String SourceEnvironmentId { get; set; }
            public System.String SourceEnvironmentName { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.SwapEnvironmentCNAMEsResponse, SetEBEnvironmentCNAMECmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
