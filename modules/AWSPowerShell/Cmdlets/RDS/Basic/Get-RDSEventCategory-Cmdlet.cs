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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Displays a list of categories for all event source types, or, if specified, for a
    /// specified source type. You can also see this list in the "Amazon RDS event categories
    /// and event messages" section of the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_Events.Messages.html"><i>Amazon RDS User Guide</i></a> or the <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/USER_Events.Messages.html"><i>Amazon Aurora User Guide</i></a>.
    /// </summary>
    [Cmdlet("Get", "RDSEventCategory")]
    [OutputType("Amazon.RDS.Model.EventCategoriesMap")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeEventCategories API operation.", Operation = new[] {"DescribeEventCategories"}, SelectReturnType = typeof(Amazon.RDS.Model.DescribeEventCategoriesResponse), LegacyAlias="Get-RDSEventCategories")]
    [AWSCmdletOutput("Amazon.RDS.Model.EventCategoriesMap or Amazon.RDS.Model.DescribeEventCategoriesResponse",
        "This cmdlet returns a collection of Amazon.RDS.Model.EventCategoriesMap objects.",
        "The service call response (type Amazon.RDS.Model.DescribeEventCategoriesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetRDSEventCategoryCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>This parameter isn't currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para>The type of source that is generating the events. For RDS Proxy events, specify <c>db-proxy</c>.</para><para>Valid Values: <c>db-instance</c> | <c>db-cluster</c> | <c>db-parameter-group</c> |
        /// <c>db-security-group</c> | <c>db-snapshot</c> | <c>db-cluster-snapshot</c> | <c>db-proxy</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventCategoriesMapList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DescribeEventCategoriesResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DescribeEventCategoriesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventCategoriesMapList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceType' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DescribeEventCategoriesResponse, GetRDSEventCategoryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            context.SourceType = this.SourceType;
            
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
            var request = new Amazon.RDS.Model.DescribeEventCategoriesRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
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
        
        private Amazon.RDS.Model.DescribeEventCategoriesResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeEventCategoriesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeEventCategories");
            try
            {
                #if DESKTOP
                return client.DescribeEventCategories(request);
                #elif CORECLR
                return client.DescribeEventCategoriesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.RDS.Model.Filter> Filter { get; set; }
            public System.String SourceType { get; set; }
            public System.Func<Amazon.RDS.Model.DescribeEventCategoriesResponse, GetRDSEventCategoryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventCategoriesMapList;
        }
        
    }
}
