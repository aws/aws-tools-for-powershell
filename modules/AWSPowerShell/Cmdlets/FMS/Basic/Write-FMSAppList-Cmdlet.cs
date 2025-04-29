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
using Amazon.FMS;
using Amazon.FMS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Creates an Firewall Manager applications list.
    /// </summary>
    [Cmdlet("Write", "FMSAppList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FMS.Model.PutAppsListResponse")]
    [AWSCmdlet("Calls the Firewall Management Service PutAppsList API operation.", Operation = new[] {"PutAppsList"}, SelectReturnType = typeof(Amazon.FMS.Model.PutAppsListResponse))]
    [AWSCmdletOutput("Amazon.FMS.Model.PutAppsListResponse",
        "This cmdlet returns an Amazon.FMS.Model.PutAppsListResponse object containing multiple properties."
    )]
    public partial class WriteFMSAppListCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppsList_AppsList
        /// <summary>
        /// <para>
        /// <para>An array of applications in the Firewall Manager applications list.</para>
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
        public Amazon.FMS.Model.App[] AppsList_AppsList { get; set; }
        #endregion
        
        #region Parameter AppsList_CreateTime
        /// <summary>
        /// <para>
        /// <para>The time that the Firewall Manager applications list was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? AppsList_CreateTime { get; set; }
        #endregion
        
        #region Parameter AppsList_LastUpdateTime
        /// <summary>
        /// <para>
        /// <para>The time that the Firewall Manager applications list was last updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? AppsList_LastUpdateTime { get; set; }
        #endregion
        
        #region Parameter AppsList_ListId
        /// <summary>
        /// <para>
        /// <para>The ID of the Firewall Manager applications list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppsList_ListId { get; set; }
        #endregion
        
        #region Parameter AppsList_ListName
        /// <summary>
        /// <para>
        /// <para>The name of the Firewall Manager applications list.</para>
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
        public System.String AppsList_ListName { get; set; }
        #endregion
        
        #region Parameter AppsList_ListUpdateToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for each update to the list. When you update the list, the update
        /// token must match the token of the current version of the application list. You can
        /// retrieve the update token by getting the list. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AppsList_ListUpdateToken { get; set; }
        #endregion
        
        #region Parameter AppsList_PreviousAppsList
        /// <summary>
        /// <para>
        /// <para>A map of previous version numbers to their corresponding <c>App</c> object arrays.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AppsList_PreviousAppsList { get; set; }
        #endregion
        
        #region Parameter TagList
        /// <summary>
        /// <para>
        /// <para>The tags associated with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.FMS.Model.Tag[] TagList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.PutAppsListResponse).
        /// Specifying the name of a property of type Amazon.FMS.Model.PutAppsListResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppsList_ListName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-FMSAppList (PutAppsList)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.PutAppsListResponse, WriteFMSAppListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AppsList_AppsList != null)
            {
                context.AppsList_AppsList = new List<Amazon.FMS.Model.App>(this.AppsList_AppsList);
            }
            #if MODULAR
            if (this.AppsList_AppsList == null && ParameterWasBound(nameof(this.AppsList_AppsList)))
            {
                WriteWarning("You are passing $null as a value for parameter AppsList_AppsList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppsList_CreateTime = this.AppsList_CreateTime;
            context.AppsList_LastUpdateTime = this.AppsList_LastUpdateTime;
            context.AppsList_ListId = this.AppsList_ListId;
            context.AppsList_ListName = this.AppsList_ListName;
            #if MODULAR
            if (this.AppsList_ListName == null && ParameterWasBound(nameof(this.AppsList_ListName)))
            {
                WriteWarning("You are passing $null as a value for parameter AppsList_ListName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppsList_ListUpdateToken = this.AppsList_ListUpdateToken;
            if (this.AppsList_PreviousAppsList != null)
            {
                context.AppsList_PreviousAppsList = new Dictionary<System.String, List<Amazon.FMS.Model.App>>(StringComparer.Ordinal);
                foreach (var hashKey in this.AppsList_PreviousAppsList.Keys)
                {
                    object hashValue = this.AppsList_PreviousAppsList[hashKey];
                    if (hashValue == null)
                    {
                        context.AppsList_PreviousAppsList.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.FMS.Model.App>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.FMS.Model.App)s);
                    }
                    context.AppsList_PreviousAppsList.Add((String)hashKey, valueSet);
                }
            }
            if (this.TagList != null)
            {
                context.TagList = new List<Amazon.FMS.Model.Tag>(this.TagList);
            }
            
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
            var request = new Amazon.FMS.Model.PutAppsListRequest();
            
            
             // populate AppsList
            var requestAppsListIsNull = true;
            request.AppsList = new Amazon.FMS.Model.AppsListData();
            List<Amazon.FMS.Model.App> requestAppsList_appsList_AppsList = null;
            if (cmdletContext.AppsList_AppsList != null)
            {
                requestAppsList_appsList_AppsList = cmdletContext.AppsList_AppsList;
            }
            if (requestAppsList_appsList_AppsList != null)
            {
                request.AppsList.AppsList = requestAppsList_appsList_AppsList;
                requestAppsListIsNull = false;
            }
            System.DateTime? requestAppsList_appsList_CreateTime = null;
            if (cmdletContext.AppsList_CreateTime != null)
            {
                requestAppsList_appsList_CreateTime = cmdletContext.AppsList_CreateTime.Value;
            }
            if (requestAppsList_appsList_CreateTime != null)
            {
                request.AppsList.CreateTime = requestAppsList_appsList_CreateTime.Value;
                requestAppsListIsNull = false;
            }
            System.DateTime? requestAppsList_appsList_LastUpdateTime = null;
            if (cmdletContext.AppsList_LastUpdateTime != null)
            {
                requestAppsList_appsList_LastUpdateTime = cmdletContext.AppsList_LastUpdateTime.Value;
            }
            if (requestAppsList_appsList_LastUpdateTime != null)
            {
                request.AppsList.LastUpdateTime = requestAppsList_appsList_LastUpdateTime.Value;
                requestAppsListIsNull = false;
            }
            System.String requestAppsList_appsList_ListId = null;
            if (cmdletContext.AppsList_ListId != null)
            {
                requestAppsList_appsList_ListId = cmdletContext.AppsList_ListId;
            }
            if (requestAppsList_appsList_ListId != null)
            {
                request.AppsList.ListId = requestAppsList_appsList_ListId;
                requestAppsListIsNull = false;
            }
            System.String requestAppsList_appsList_ListName = null;
            if (cmdletContext.AppsList_ListName != null)
            {
                requestAppsList_appsList_ListName = cmdletContext.AppsList_ListName;
            }
            if (requestAppsList_appsList_ListName != null)
            {
                request.AppsList.ListName = requestAppsList_appsList_ListName;
                requestAppsListIsNull = false;
            }
            System.String requestAppsList_appsList_ListUpdateToken = null;
            if (cmdletContext.AppsList_ListUpdateToken != null)
            {
                requestAppsList_appsList_ListUpdateToken = cmdletContext.AppsList_ListUpdateToken;
            }
            if (requestAppsList_appsList_ListUpdateToken != null)
            {
                request.AppsList.ListUpdateToken = requestAppsList_appsList_ListUpdateToken;
                requestAppsListIsNull = false;
            }
            Dictionary<System.String, List<Amazon.FMS.Model.App>> requestAppsList_appsList_PreviousAppsList = null;
            if (cmdletContext.AppsList_PreviousAppsList != null)
            {
                requestAppsList_appsList_PreviousAppsList = cmdletContext.AppsList_PreviousAppsList;
            }
            if (requestAppsList_appsList_PreviousAppsList != null)
            {
                request.AppsList.PreviousAppsList = requestAppsList_appsList_PreviousAppsList;
                requestAppsListIsNull = false;
            }
             // determine if request.AppsList should be set to null
            if (requestAppsListIsNull)
            {
                request.AppsList = null;
            }
            if (cmdletContext.TagList != null)
            {
                request.TagList = cmdletContext.TagList;
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
        
        private Amazon.FMS.Model.PutAppsListResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.PutAppsListRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "PutAppsList");
            try
            {
                return client.PutAppsListAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.FMS.Model.App> AppsList_AppsList { get; set; }
            public System.DateTime? AppsList_CreateTime { get; set; }
            public System.DateTime? AppsList_LastUpdateTime { get; set; }
            public System.String AppsList_ListId { get; set; }
            public System.String AppsList_ListName { get; set; }
            public System.String AppsList_ListUpdateToken { get; set; }
            public Dictionary<System.String, List<Amazon.FMS.Model.App>> AppsList_PreviousAppsList { get; set; }
            public List<Amazon.FMS.Model.Tag> TagList { get; set; }
            public System.Func<Amazon.FMS.Model.PutAppsListResponse, WriteFMSAppListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
